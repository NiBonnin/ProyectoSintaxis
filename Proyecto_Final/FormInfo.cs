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
    public partial class FormInfo : Form
    {
        private String info = 
            "Asigación" + Environment.NewLine +
            "   variable = datoNumerico;" + Environment.NewLine + Environment.NewLine +
            "Operaciones" + Environment.NewLine +
            "   + - * /" + Environment.NewLine +
            "   Ejemplo: 1 + 1;" + Environment.NewLine +
            "   Separadores entre operaciones: ( )" + Environment.NewLine + Environment.NewLine +
            "Relacionales" + Environment.NewLine +
            "   < > == !=" + Environment.NewLine + Environment.NewLine +
            "Obtener dato por usuario" + Environment.NewLine +
            "   READ(\"Texto a mostrar\", variable);" + Environment.NewLine +
            "   Mostrar dato por pantalla" + Environment.NewLine +
            "   WRITE(\"Texto a mostrar\", variable);" + Environment.NewLine + Environment.NewLine +
            "Condicional" + Environment.NewLine +
            "   IF(condicion) THEN codigo a ejecutar SINO codigo a ejecutar END;" + Environment.NewLine + Environment.NewLine +
            "Ciclo" + Environment.NewLine +
            "   WHILE(condicion) DO codigo a ejecutar END;" + Environment.NewLine + Environment.NewLine +
            "Condición" + Environment.NewLine +
            "  Negar expresión: NOT" + Environment.NewLine +
            "  Agregar más condiciones: AND OR" + Environment.NewLine +
            "  Separadores entre condiciones: [ ] ";
        public FormInfo()
        {
            InitializeComponent();
            tboxInfo.Text = info;
        }
    }
}
