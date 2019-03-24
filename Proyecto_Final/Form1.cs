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
    public partial class Form1 : Form
    {
        AnalizadorLex oAlex;
        AnalizadorSint oAsint;
        bool evento = false;  // se cambia a true si se validaron los lexemas


        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            oAlex = new AnalizadorLex();
            
             oAsint= new AnalizadorSint();
            string texto = textBox1.Text;
            texto = texto.Replace(Environment.NewLine, "").Replace(" ",""); // eliminas espacios salto de linea y demas
            texto = texto += "$";     //marca final de la string
            if (texto != "$")
            { oAlex.SetCadenaEntrada(texto);
                oAlex.AutomataReconocedor();
                string[] lexemas = oAlex.GetLexemas().ToArray();
                string[] descripcion = oAlex.GetDescripcion().ToArray();
                int longlexemas = lexemas.Length;
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(longlexemas);
                for (int i = 0; i < longlexemas; i++)  // hacer hasta tipos -1 para no mostrar el $ que marca el final
                {
                    dataGridView1.Rows[i].Cells[0].Value = lexemas[i];
                    dataGridView1.Rows[i].Cells[1].Value = descripcion[i];

                }

                evento = true;
            }
            else
            {
                label2.Text = "Error, no se ha ingresado codigo";
                
            }





        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (evento == false)  // si el primer elemento esta vacio, no pesee nada
            { label2.Text = "No se a cargado la expresion o no valido el codigo"; }
            else if (oAlex.Validar()==false)  // si no se encontro ningun desconocido , sino no deja hacer analisis lexico
            {
                string[] tipos = oAlex.GetAnalizar().ToArray();
                oAsint.InicializarPila(); // inicia pila con tope = a simbolo inicial de gramatica y el fondo "$"
                oAsint.SetLexemas(oAlex.GetAnalizar().ToArray());  // carga lexema (en esta pruebe)
                if (oAsint.Analizar() == true)
                { label2.Text = "Sintaxis correcta "; }
                else
                { label2.Text = "Sintaxis incorrecta "; }
            }
            else
            { label2.Text = "Se a ingresado un caracter desconocido"; }




        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
