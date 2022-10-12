using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace proyecto3._1
{
    public partial class Opciones : Form
    {
        Form1 f1;
        public Opciones()
        {
            InitializeComponent();
            f1 = null;
        }
        public Opciones(Form1 f1)
        {
            InitializeComponent();
            this.f1 = f1;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if(this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.panel1.BackColor = colorDialog1.Color;
                f1.colorTexto(colorDialog1.Color);
                f1.newColor(colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B);

                String linea = Path.GetFullPath("Color.txt");
                f1.notificacion(linea);

                StreamWriter sw = new StreamWriter(linea,false);

                sw.Write(colorDialog1.Color.R + ";" + colorDialog1.Color.G + ";" + colorDialog1.Color.B);
                sw.Close();
            }
        }

        public void SaveFile(String nombre, String fuente,float size, FontStyle style)
        {
            string linea = Path.GetFullPath(nombre);
            StreamWriter sw = new StreamWriter(linea, false);
            sw.Write(fuente + ";" + size.ToString() + ";" + Convert.ToInt32(style));
            sw.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                string name = fontDialog1.Font.Name;
                float size = fontDialog1.Font.Size;
                FontStyle stilo =  fontDialog1.Font.Style;
                
                f1.fuente(name,size,stilo);
                SaveFile("fuente.data",name,size,stilo);
            }
        }
    }
}
