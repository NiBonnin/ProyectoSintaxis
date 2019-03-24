using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sintaxis   //programa prueba
{
    public partial class Form1 : Form
    {

        AnalizadorLex oAlex = new AnalizadorLex();
        AnalisadorSint oAns = new AnalisadorSint();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // solo 1 asignacion a los id , volver a cargar para hacer de nuevo
         {
            string texto = ventana.Text;
            texto = texto.Replace(" ", "");
            texto = texto +="$";     //marca final de la string
            oAlex.SetCadenaEntrada(texto);
            oAlex.AutomataReconocedor();
            string[] lexemas = oAlex.GetLexemas();
            string[] tipos = oAlex.GetTipos();
            int longlexemas = lexemas.Length;
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(longlexemas);
            for (int i = 0; i < longlexemas; i++)  // hacer hasta tipos -1 para no mostrar el $ que marca el final
            {
                dataGridView1.Rows[i].Cells[0].Value = lexemas[i];
                dataGridView1.Rows[i].Cells[1].Value = tipos[i];
               
            }


            /* string texto = ventana.Text; // obtine texto del textbox
             string[] separadas;
             separadas = texto.Split();  // pone en vector la palabras separadas

             separadas = separadas.Where(i => i != "").ToArray(); //crea nuevo array sin espacios en blanco con la palabras separadas
             int longseparadas = separadas.Length;

             Aut.SetEstados(longseparadas);
             Aut.SetTipos(longseparadas);

             Aut.AnalizarTexto(separadas);


              Aut.Reconosedor(separadas);
               string[] estados = Aut.GetEstados();
               string[] tipos = Aut.GetTipo();
             dataGridView1.Rows.Clear();
             dataGridView1.Rows.Add(longseparadas);
             for (int i = 0; i < longseparadas; i++)
             {
                 dataGridView1.Rows[i].Cells[0].Value = separadas[i];
                 dataGridView1.Rows[i].Cells[1].Value = tipos[i];
                 dataGridView1.Rows[i].Cells[2].Value = estados[i]; 
             }

             int num = texto.Length;
             label2.Text =Convert.ToString(num);*///anterior

        }

        private void label2_Click(object sender, EventArgs e)
        {
          








        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] tipos = oAlex.GetTipos();
            if (tipos[0] == null)  // si el primer elemento esta vacio, no pesee nada
            { label2.Text = "No se a cargado la expresion"; }

            else
            {
                oAns.SetTas(); // carga la tas
                oAns.InicializarPila(); // inicia pila con tope = a simbolo inicial de gramatica y el fondo "$"
                oAns.SetLexemas(oAlex.GetTipos());  // carga lexema (en esta pruebe)
                if (oAns.Analizar() == true)
                { label2.Text = "Sintaxis correcta "; }
                else
                { label2.Text = "Sintaxis incorrecta "; }
            }


            /*
            oAns.SetTas(); // carga la tas
            oAns.InicializarPila(); // inicia pila con tope = a simbolo inicial de gramatica y el fondo "$"
           oAns.SetLexemas();  // carga lexema (en esta pruebe)
            if (oAns.Analizar() == true)
            { label2.Text = "Sintaxis correcta "; }
            else
            { label2.Text = "Sintaxis incorrecta "; }*/

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ventana_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
