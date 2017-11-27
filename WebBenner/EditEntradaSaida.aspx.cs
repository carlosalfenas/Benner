using System;
using System.Web.UI;

namespace WebBenner
{
    public partial class EditEntradaSaida : System.Web.UI.Page
    {
        #region Propriedades
        private int IdEntradaSaida
        {
            get { return (int)(ViewState["IdEntradaSaida"] ?? 0); }
            set { ViewState["IdEntradaSaida"] = value; }
        }

        private int IdPreco
        {
            get { return (int)(ViewState["IdPreco"] ?? 0); }
            set { ViewState["IdPreco"] = value; }
        }

        private double Preco
        {
            get { return (double)(ViewState["Preco"] ?? 0); }
            set { ViewState["Preco"] = value; }
        }

        private double PrecoAdicional
        {
            get { return (double)(ViewState["PrecoAdicional"] ?? 0); }
            set { ViewState["PrecoAdicional"] = value; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindPreco();
                txtPlaca.Focus();
                int id = 0;
                if (Int32.TryParse(Request.QueryString["ID"], out id))
                {
                    IdEntradaSaida = Convert.ToInt32(id);
                    if (IdEntradaSaida > 0)
                        BindEntradaSaida(IdEntradaSaida);
                }
            }
        }

        private void BindPreco()
        {      
            var precos = new Repository.RepPrecos();
            var dt = precos.Read(DateTime.Now.Date);
            if (dt.Rows.Count > 0)
            {
                IdPreco = Convert.ToInt32(dt.Rows[0]["IdPreco"].ToString());
                Preco = Convert.ToDouble(dt.Rows[0]["Preco"].ToString());
                PrecoAdicional = Convert.ToDouble(dt.Rows[0]["PrecoAdicional"].ToString());
                txtPreco.Text = dt.Rows[0]["Preco"].ToString();
                txtPrecoAdicional.Text = dt.Rows[0]["PrecoAdicional"].ToString();
            }
        }

        private void BindEntradaSaida(int idEntradaSaida)
        {
            var entradasaida = new Repository.RepEntradaSaida();
            var dt = entradasaida.Read(idEntradaSaida);

            if (dt.Rows.Count > 0)
            {
                TxtHorarioSaida.Focus();
                TxtHorarioSaida.Enabled = true;         
                txtPlaca.Text = dt.Rows[0]["PlacaVeiculo"].ToString();
                txtHorarioChegada.Text = dt.Rows[0]["HorarioChegada"].ToString();
            }
        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            GravarDados();
        }

        private void GravarDados()
        {
            if (IdEntradaSaida == 0)
                GravaEntradaVeiculos();
            else
                GravaSaidaVeiculos();
        }

        private void GravaEntradaVeiculos()
        {
            if (txtPlaca.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Digite a Placa do Veículo!')", true);
                txtPlaca.Focus();
                return;
            }
            var entradasaida = new Repository.RepEntradaSaida();
            var es = new Entities.EntradaSaida();
            int verifica = 0;
            es.IdEntradaSaida = 0;
            es.PlacaVeiculo = txtPlaca.Text;
            es.HorarioChegada = Convert.ToDateTime(txtHorarioChegada.Text);
            verifica = entradasaida.Create(es);

            if (verifica > 0)
                Response.Redirect("/EntradaSaida.aspx");
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível gravar este Registro! Entre em Contato com o Administrador do Sistema')", true);

        }

        private void GravaSaidaVeiculos()
        {
            var entradasaida = new Repository.RepEntradaSaida();
            var es = new Entities.EntradaSaida();
            int verifica = 0;
            es.IdPreco = IdPreco;
            es.IdEntradaSaida = IdEntradaSaida;
            es.PlacaVeiculo = txtPlaca.Text;
            es.HorarioChegada = Convert.ToDateTime(txtHorarioChegada.Text);
            es.HorarioSaida = Convert.ToDateTime(TxtHorarioSaida.Text);
            //Calcula Durancao do tempo
            es.Duracao = CalculaDuracao(Convert.ToDateTime(txtHorarioChegada.Text));
            //Calcula Tempo Cobrado
            es.TempoCobrado = CalculaTempoCobrado(Convert.ToDateTime(txtHorarioChegada.Text));
            //Calcula valor a pagar
            es.ValorPagar = CalculaValorPagar(Convert.ToDateTime(txtHorarioChegada.Text));

            verifica = entradasaida.Update(es);

            if (verifica > 0)
                Response.Redirect("/EntradaSaida.aspx");
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível gravar este Registro! Entre em Contato com o Administrador do Sistema')", true);

        }

        private DateTime CalculaDuracao(DateTime horarioEntrada)
        {
            var horarioSaida = Convert.ToDateTime(TxtHorarioSaida.Text);
            var result = horarioSaida - horarioEntrada;
            return Convert.ToDateTime(result.ToString().Substring(0, 8));
        }

        private int CalculaTempoCobrado(DateTime horarioEntrada)
        {
            int resultado = 0;
            var horarioAtual = DateTime.Now;
            var duracao = CalculaDuracao(horarioEntrada);

            if (duracao.Hour == 0 && duracao.Minute >= 10)
            {
                resultado = 1;
            }

            else if (duracao.Hour > 0 && duracao.Minute > 10)
            {
                resultado = duracao.Hour + 1;
            }
            
            else
                resultado = duracao.Hour;

            return resultado;
        }

        private double CalculaValorPagar(DateTime horarioEntrada)
        {
            double valorapagar = 0;

            var tempo = CalculaDuracao(horarioEntrada);

            if (tempo.Hour == 0)
            {
                if (tempo.Minute <= 30)
                {
                    valorapagar = Preco / 2;
                }
                else
                    valorapagar = Preco;
            }
            else if (tempo.Minute > 10)
            {
                valorapagar = tempo.Hour * Preco + PrecoAdicional;
            }
            else
                valorapagar = tempo.Hour * Preco;

            return valorapagar;
        }
    }
}