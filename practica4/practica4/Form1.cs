namespace practica4
{
    public partial class Form1 : Form
    {
        String direccion;
        int column;
        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            direccion = Path.GetFullPath("bitacora.txt");
            if (!File.Exists(direccion))
            {
                StreamWriter sw = new StreamWriter(direccion,false);
                sw.Close();
            }

            String fecha = DateTime.Now.ToString();
            column = - 1;

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guardar();
        }
        public void guardar()
        {
            direccion = Path.GetFullPath("bitacora.txt");
            StreamWriter sw = new StreamWriter(direccion, true);
            String aux;
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    aux = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    aux += "@" + dataGridView1.Rows[i].Cells[1].Value.ToString();
                    sw.WriteLine(aux);
                }
                sw.Close();
            }
            catch(Exception ex)
            {
                sw.Close ();
            }
            dataGridView1.Rows.Clear();
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows[index].Cells[1].Value
                        = DateTime.Now.ToString();
        }

        private void muestraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            muestra m = new muestra();
            m.Show();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buscar b = new buscar();
            b.Show();
        }
    }
}