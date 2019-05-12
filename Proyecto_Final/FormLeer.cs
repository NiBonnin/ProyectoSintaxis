using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Final
{
    public partial class FormLeer : Form
    {
        public FormLeer(String lblTexto)
        {
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            InitializeComponent();
            this.lblTexto.Text = lblTexto;
            btnAceptar.Enabled = false;
        }

        private void tboxDato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        public String ValorIngresado { get => this.tboxDato.Text;}

        private void tboxDato_TextChanged(object sender, EventArgs e)
        {
            bool error = false;

            if (!String.IsNullOrEmpty(tboxDato.Text))
            {
                string texto = tboxDato.Text;
                string texto2 = tboxDato.Text.Substring(1);
                string texto3 = Reverse(texto);

                if ((texto[0] == ',') || (texto2.Contains('-') || (texto3[0] == ',')))  // empieza con coma, tiene un menos y no es primer caracter,
                {                                                                       // no tiene numero despues de la coma final
                    error = true;
                }
            } else
            {
                error = true;
            }

            if (error)
            {
                errorProvider1.SetError(tboxDato, "Datos erroneos o faltantes");
                btnAceptar.Enabled = false;
            }
            else
            {
                errorProvider1.Clear();
                btnAceptar.Enabled = true;
            }
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
