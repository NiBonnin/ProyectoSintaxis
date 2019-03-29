﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Proyecto_Final
{
    public partial class FormInterprete : Form
    {
        AnalizadorLex aLexico;
        AnalizadorSint aSint;
        Evaluador evaluador;
        bool elementosReconocidos;  // se cambia a true si se validaron los lexemas


        public FormInterprete()
        {
            InitializeComponent();
        }

        private void btnReconocerElementos_Click(object sender, EventArgs e)
        {
            reiniciar();
            string texto = tboxCodigoAAnalizar.Text.Replace(Environment.NewLine, " "); // se eliminan espacios y salto de linea
            if (!String.IsNullOrEmpty(texto))
            {
                texto += "$";     //marca final de la string
                aLexico.SetCadenaEntrada(texto);
                aLexico.AutomataReconocedor();
                string[] lexemas = aLexico.GetLexemas().ToArray();
                string[] descripcion = aLexico.GetDescripcion().ToArray();
                int longlexemas = lexemas.Length;
                dGridTablaLexemas.Rows.Add(longlexemas);
                for (int i = 0; i < longlexemas; i++)  // hacer hasta tipos -1 para no mostrar el $ que marca el final
                {
                    dGridTablaLexemas.Rows[i].Cells[0].Value = lexemas[i];
                    dGridTablaLexemas.Rows[i].Cells[1].Value = descripcion[i];
                }
                elementosReconocidos = true;
            }
            else
            {
                MessageBox.Show("Error, no se ha ingresado codigo");
            }
        }

        private void btnValidarSintaxis_Click(object sender, EventArgs e)
        {
            String textoResultado;
            if (!elementosReconocidos)  // si el primer elemento esta vacio, no posee nada
            {
                textoResultado = "No se ha cargado la expresion o no valido el codigo";
            }
            else if (!aLexico.ContieneLexemaDesconocido())  // si no se encontro ningun desconocido , sino no deja hacer analisis lexico
            {
                string[] tipos = aLexico.GetAnalizar().ToArray();
                aSint.InicializarPila(); // inicia pila con tope = a simbolo inicial de gramatica y el fondo "$"
                aSint.SetLexemas(aLexico.GetAnalizar().ToArray());  // carga lexema (en esta pruebe)
                if (aSint.Analizar())
                {
                    textoResultado = "Sintaxis correcta ";
                    btnEvaluar.Enabled = true;
                }
                else
                { textoResultado = "Sintaxis incorrecta "; }
            }
            else
            {
                textoResultado = "Se ha ingresado un caracter desconocido";
            }
            MessageBox.Show(textoResultado);
        }

        private void btnEvaluar_Click(object sender, EventArgs e)
        {
            evaluador = new Evaluador();
            List<String> listaMostrar = evaluador.EvalProgPrincipal(aSint.Arbol);
            String lineaMostrar = "";
            foreach (String linea in listaMostrar)
            {
                lineaMostrar += " " + linea;
            }
            MessageBox.Show(lineaMostrar);
        }

        private void reiniciar()
        {
            elementosReconocidos = false;
            aLexico = new AnalizadorLex();
            aSint = new AnalizadorSint();
            dGridTablaLexemas.Rows.Clear();
            btnEvaluar.Enabled = false;
        }

        private void btnPrograma1_Click(object sender, EventArgs e)
        {
            String programa = "i = 3;" + Environment.NewLine +
                              "a = 2;" + Environment.NewLine +
                              "u = i + a;";
            tboxCodigoAAnalizar.Text = programa;
        }

        private void btnPrograma2_Click(object sender, EventArgs e)
        {
            String programa = "READ(\"Ingresar dato\", a);" + Environment.NewLine +
                              "b = 4;" + Environment.NewLine +
                              "WHILE (b < 10) DO b + a;" + Environment.NewLine +
                              "WRITE(\"Valor resultado de b\", b);";
            tboxCodigoAAnalizar.Text = programa;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            reiniciar();
            tboxCodigoAAnalizar.Clear();
        }
    }
}
