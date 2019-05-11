using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            if (tboxDato.Text != "")
            {   string texto = tboxDato.Text;
                string texto2 = tboxDato.Text.Substring(1);
                string texto3 = Reverse(texto);  // string dada vuelta

                if (texto[0] == ',')  // si empieza con , el numero esta mal escrito
                { error = true; }

                if (texto2.Contains('-'))  // si contiene un menos dsp del primer elemento esta mal
                { error = true; }

                if (texto3[0] == ',') // si termina con coma esta mal
                { error = true; }
            }
            if (tboxDato.Text == "") // si no se ingreso nada
            { error = true; }

            if (error)
            {
                errorProvider1.SetError(tboxDato, "Datos erroneos o falantes");
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

        private void tboxDato_Validating(object sender, CancelEventArgs e)
        {





        }

        
    }
}
