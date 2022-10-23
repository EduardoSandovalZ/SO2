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

namespace chatWindows
{
    public partial class crear : Form
    {
        public crear()
        {
            InitializeComponent();
        }
        private void crear_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String cliente = "";
            string usuario = "123";
            string descripcion = "";

            cliente = textBox1.Text;
            descripcion = textBox2.Text;

            String url = "http://serviciosdigitalesplus.com/chat/?tipo=1&cliente=" 
                + cliente + "&descripcion=" + descripcion + "&usuario=" + usuario ;
            String texto = (new WebClient().DownloadString(url));

        }

       
    }
}
