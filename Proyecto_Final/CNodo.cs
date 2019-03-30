using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    class CNodo
    {
        private string dato;
        private bool tratado;
        private String descripcion;

        private CNodo hijo;
        private CNodo hermano;


        public string Dato { get => dato; set => dato = value; }
        public String Descripcion { get => descripcion; set => descripcion = value; }
        public bool Tratado { get => tratado; set => tratado = value; } // valor para encontrar un nodo que no fue traado
        public CNodo Hijo { get => hijo; set => hijo = value; }
        public CNodo Hermano { get => hermano; set => hermano = value; }
        
        public CNodo()
        {
            dato = "";
            tratado = false;
            hijo = null;
            hermano = null;

        }



    }
}
