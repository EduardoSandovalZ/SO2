using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load();
        }

        public void load()
        {
            dataGridView1.Rows.Clear();
            String url = "http://serviciosdigitalesplus.com/servicio/servicio.php?tipo=1&clave=2304";
            String texto = (new WebClient().DownloadString(url));
            Root r = JsonConvert.DeserializeObject<Root>(texto);

            for (int i = 0; i < r.dato.Count; i++)
            {
                int j = dataGridView1.Rows.Add();
                dataGridView1.Rows[j].Cells[0].Value = r.dato[i].id.ToString();
                dataGridView1.Rows[j].Cells[1].Value = r.dato[i].nom.ToString();
                dataGridView1.Rows[j].Cells[2].Value = r.dato[i].app.ToString();
                dataGridView1.Rows[j].Cells[3].Value = r.dato[i].tel.ToString();
                dataGridView1.Rows[j].Cells[4].Value = r.dato[i].clave.ToString();
            }
        }
    }
    public class Dato
    {
        public string id { get; set; }
        public string nom { get; set; }
        public string app { get; set; }
        public string tel { get; set; }
        public string clave { get; set; }
    }

    public class Root
    {
        public List<Dato> dato { get; set; }
    }
}
