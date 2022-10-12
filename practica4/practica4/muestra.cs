using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica4
{
    public partial class muestra : Form
    {
        public muestra()
        {
            InitializeComponent();
        }

        private void muestra_Load(object sender, EventArgs e)
        {
            String direccion = Path.GetFullPath("bitacora.txt");
            if (File.Exists(direccion))
            {
                StreamReader sr = new StreamReader(direccion);
                String linea = "";
                while ((linea = sr.ReadLine())!=null)
                {
                    String[] arr = linea.Split('@');
                    //
                    int i = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[i].Cells[0].Value = arr[0];
                    this.dataGridView1.Rows[i].Cells[1].Value = arr[1];
                }
                sr.Close();
            }
        }
    }
}
