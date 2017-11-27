using System;
using System.Web.UI;

namespace WebBenner
{
    public partial class EditTaxas : System.Web.UI.Page
    {

        private int IdPreco
        {
            get { return (int)(ViewState["IdPreco"] ?? 0); }
            set { ViewState["IdPreco"] = value; }
        }

        public void InicializaComponetes()
        {
            txtPreco.Attributes.Add("onkeypress", "return apenasnumerosvirgula( this , event )");
            txtPrecoAdicional.Attributes.Add("onkeypress", "return apenasnumerosvirgula( this , event )");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            InicializaComponetes();

            if (!Page.IsPostBack)
            {
                chkAtivo.Checked = true;
                int id = 0;

                if (Int32.TryParse(Request.QueryString["ID"], out id))
                {
                    IdPreco = Convert.ToInt32(id);
                    if (IdPreco > 0)
                        Bind(IdPreco);
                }
            }
        }


        private void Bind(int? IdPreco)
        {
            var precos = new Repository.RepPrecos();
            var dt = precos.Read(DateTime.Now.Date);

            if (dt.Rows.Count > 0)
            {
                txtDescricao.Text = dt.Rows[0]["Descricao"].ToString();
                txtPreco.Text = dt.Rows[0]["Preco"].ToString();
                txtPrecoAdicional.Text = dt.Rows[0]["PrecoAdicional"].ToString();
                chkAtivo.Checked = Convert.ToBoolean(dt.Rows[0]["Flag"].ToString());
            }
        }

        public Boolean ValidarDados()
        {
            Boolean flag = true;              

            if (txtDescricao.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Digite uma Descrição!')", true);
                flag = false;
            }
            else if (txtPreco.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Digite um Preço!')", true);
                flag = false;
            }

            else if (txtPrecoAdicional.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Digite um Preço Adicional!')", true);
                flag = false;
            }

            return flag;
        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            if (ValidarDados())
            {
                GravarDados();
            }
        }

        private void GravarDados()
        {
            var e = new Entities.Precos();
            var precos = new Repository.RepPrecos();
            int verifica = 0;
            e.IdPreco = IdPreco;
            e.Descricao = txtDescricao.Text;
            e.Preco = Convert.ToDouble(txtPreco.Text);
            e.PrecoAdicional = Convert.ToDouble(txtPrecoAdicional.Text);
            e.DataInicioVigencia = Convert.ToDateTime(txtInicioVigencia.Text);
            e.DataFimVigencia = Convert.ToDateTime(txtFimVigencia.Text);
            e.Flag = Convert.ToBoolean(chkAtivo.Checked);
            precos.ClearFlag();

            verifica = IdPreco > 0 ? precos.Update(e) : precos.Create(e);
            if (verifica > 0)
                Response.Redirect("/Taxas.aspx");
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível gravar este Registro! Entre em Contato com o Administrador do Sistema')", true);
        }
    }
}