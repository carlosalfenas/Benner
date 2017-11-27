using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBenner
{
    public partial class EntradaSaida : System.Web.UI.Page
    {

        private int IdEntradaSaida
        {
            get { return (int)(ViewState["IdEntradaSaida"] ?? 0); }
            set { ViewState["IdEntradaSaida"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bind(0);
            }
        }

        protected void GVEntradaSaida_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVEntradaSaida.PageIndex = e.NewPageIndex;
            Bind(0);
        }

        protected void GVEntradaSaida_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Image abertofechado;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                 var  DataSaida = DataBinder.Eval(e.Row.DataItem, "HorarioSaida").ToString();
                abertofechado = (Image)e.Row.FindControl("btnEdit");

                if (DataSaida != null && DataSaida != "")
                {
                    abertofechado.ImageUrl = "../images/cadeadofechado.png";
                    abertofechado.ToolTip = "Saída Fechada";
                    abertofechado.Attributes.Add("onclick",
                             "javascript:alert('Saida já efetuada');return false;");
                }
            }
        }

        private void Bind(int? idEntradaSaida)
        {
            lblHorario.Text = Datadia();
            var es = new Repository.RepEntradaSaida();
            var dt = es.Read(idEntradaSaida);

            GVEntradaSaida.DataSource = dt;
            GVEntradaSaida.DataBind();

        }


        public string Datadia()
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;

            int dia = DateTime.Now.Day;
            int ano = DateTime.Now.Year;
            string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month));
            string diasemana = culture.TextInfo.ToTitleCase(dtfi.GetDayName(DateTime.Now.DayOfWeek));
            string data = diasemana + ", " + dia + " de " + mes + " de " + ano;

            return data;
        }

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)((ImageButton)sender).NamingContainer;
            if (GVEntradaSaida != null)
            {
                Int32 IdEntradaSaida = Convert.ToInt32(GVEntradaSaida.DataKeys[gvRow.RowIndex]?.Value);
                Response.Redirect("~/EditEntradaSaida.aspx" + "?ID=" + IdEntradaSaida);
            }
        }

        protected void btnExcluir_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)((ImageButton)sender).NamingContainer;
            if (GVEntradaSaida != null)
            {
                Int32 IdEntradaSaida = Convert.ToInt32(GVEntradaSaida.DataKeys[gvRow.RowIndex]?.Value);

                var es = new Repository.RepEntradaSaida();

                if (es.Delete(IdEntradaSaida))
                {
                    Bind(null);
                }
            }
        }
        
        protected void BtnNovaTaxa_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EditEntradaSaida.aspx");
        }
         
 
 
    }
}