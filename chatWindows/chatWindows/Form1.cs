using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;

namespace chatWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public void load()
        {
            dataGridView1.Rows.Clear();
            String url = "http://serviciosdigitalesplus.com/chat/?tipo=2&usuario=201907866";

            String texto = (new WebClient().DownloadString(url));
            Root r = JsonConvert.DeserializeObject<Root>(texto);

            for (int i = 0; i < r.chat.Count; i++)
            {
                int j = this.dataGridView1.Rows.Add();
                dataGridView1.Rows[j].Cells[0].Value = r.chat[i].cliente.ToString();
                dataGridView1.Rows[j].Cells[1].Value = r.chat[i].usuario.ToString();
                dataGridView1.Rows[j].Cells[2].Value = r.chat[i].descripcion.ToString();
                dataGridView1.Rows[j].Cells[3].Value = r.chat[i].fecha.ToString();
            }
        }

        public void crear()
        {
           
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crear c = new crear();
            c.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public class Chat
    {
        public string cliente { get; set; }
        public string usuario { get; set; }
        public string descripcion { get; set; }
        public string fecha { get; set; }
    }

    public class Root
    {
        public List<Chat> chat { get; set; }
    }
}
