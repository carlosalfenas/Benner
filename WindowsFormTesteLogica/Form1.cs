using System;
using System.Windows.Forms;
using TesteLogica;

namespace WindowsFormTesteLogica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnAdicionarListaArrays_Click(object sender, EventArgs e)
        {
            try
            {
                var array = new Network();
                var ret = array.Construtor(Convert.ToInt32(txtListaArrays.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Valor Invalido");
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                MessageBox.Show("Valor Invalido");
            }

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                MessageBox.Show("Valor Invalido");
            }

        }
    }
}
