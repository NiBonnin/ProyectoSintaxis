using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Sintaxis
{
    public partial class Form1 : Form
    {

        Lexico oAnaLex = new Lexico();
        SintDescNRP oAnaSintDesc = new SintDescNRP();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            oAnaLex.Inicia();
            oAnaLex.Analiza(textBox1.Text);
            dataGridView1.Rows.Clear();
            if (oAnaLex.NoTokens > 0)
                dataGridView1.Rows.Add(oAnaLex.NoTokens);
            for (int i = 0; i < oAnaLex.NoTokens; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = oAnaLex.Token[i];
                dataGridView1.Rows[i].Cells[1].Value = oAnaLex.Lexema[i];
            }
            oAnaSintDesc.Inicia();
             if (oAnaSintDesc.Analiza(oAnaLex) == 0)
                 label2.Text = "ANALISIS SINTACTICO EXITOSO";
             else
                 label2.Text = "ERROR DE SINTAXIS"; 
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
