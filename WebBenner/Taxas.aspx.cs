using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBenner
{
    public partial class Taxas : Page
    {

        private int IdPreco
        {
            get { return (int)(ViewState["IdPreco"] ?? 0); }
            set { ViewState["IdPreco"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bind();
            }
        }

        protected void GVTaxas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVTaxas.PageIndex = e.NewPageIndex;
            Bind();
        }

        protected void GVTaxas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var chkDados = (CheckBox)e.Row.FindControl("Flag");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var flag = DataBinder.Eval(e.Row.DataItem, "Flag").ToString();
                if (Convert.ToBoolean(flag))
                    chkDados.Checked = true;
            }
        }

        private void Bind()
        {
            var precos = new Repository.RepPrecos();
            var dt = precos.Read(DateTime.Now.Date);
            GVTaxas.DataSource = dt;
            GVTaxas.DataBind();
        }

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)((ImageButton)sender).NamingContainer;
            if (GVTaxas != null)
            {
                Int32 IdPreco = Convert.ToInt32(GVTaxas.DataKeys[gvRow.RowIndex]?.Value);
                Response.Redirect("~/EditTaxas.aspx" + "?ID=" + IdPreco);
            }
        }

        protected void btnExcluir_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)((ImageButton)sender).NamingContainer;
            if (GVTaxas != null)
            {
                Int32 IdPreco = Convert.ToInt32(GVTaxas.DataKeys[gvRow.RowIndex]?.Value);

                var precos = new Repository.RepPrecos();

                if (precos.Delete(IdPreco))
                {
                    Bind();
                }
            }
        }

    }
}