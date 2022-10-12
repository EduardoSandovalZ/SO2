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
    public partial class buscar : Form
    {
        public buscar()
        {
            InitializeComponent();
        }

        private void buscar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            dataGridView1.Rows.Clear();
            find(this.dateTimePicker1.Value.ToShortDateString());
        }
        public void find(String encontrar)
        {
            //String[] arrFecha = encontrar.Split(' ');
            String f1 = encontrar;
            String direccion = Path.GetFullPath("bitacora.txt");
            if (File.Exists(direccion))
            {
                StreamReader sr = new StreamReader(direccion);
                String linea = "";
                while ((linea = sr.ReadLine()) != null)
                {
                    String[] arr = linea.Split('@');
                    if (arr[1].Contains(f1))
                    {
                        int i = this.dataGridView1.Rows.Add();
                        this.dataGridView1.Rows[i].Cells[0].Value = arr[0];
                        this.dataGridView1.Rows[i].Cells[1].Value = arr[1];
                    }
                }
                sr.Close();
            }
        }
    }
}
