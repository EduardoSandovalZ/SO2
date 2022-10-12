namespace AgendaBinaria
{
    public partial class Form1 : Form
    {
        int column = 0; 
        String Archivo;
        List<person> lista = new List<person>();
        fichero f = new fichero();
        public Form1()
        {
            InitializeComponent();
            f = new fichero();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files(*.txt)|.txt|All files(*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Archivo = openFileDialog1.FileName;
                List<person> lista = f.leerArchivo(Archivo);

                for (int i = 0; i < lista.Count; i++)
                {
                    person p = lista.ElementAt(i);
                    int n = this.dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = p.id;
                    dataGridView1.Rows[n].Cells[1].Value = p.nom;
                    dataGridView1.Rows[n].Cells[2].Value = p.tel;
                }

            }
        }

        private void guardarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            guardarComo();
        }

        public void guardarComo()
        {
            saveFileDialog1.Filter = "txt files(*.txt)|.txt|All files(*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Archivo = saveFileDialog1.FileName;
                llenarLista();

                f.EscribeArchivo(Archivo, lista);
            }
        }
        public void llenarLista()
        {
            lista.Clear();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                person p = new person();
                p.id = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                p.nom = dataGridView1.Rows[i].Cells[1].Value.ToString();
                p.tel = Convert.ToInt32(dataGridView1.Rows [i].Cells[2].Value.ToString());

                lista.Add(p);
            }
        }



        public class person
        {
            public int id;
            public String nom;
            public int tel;

            public void load(int id, String nom, int tel)
            {
                this.id = id;
                this.nom = nom;
                this.tel = tel;
            }
        } 
        public class fichero
        {
            public int EscribeArchivo(String url, List<person> lista)
            {
                BinaryWriter ficheroSalida;

                try
                {
                    ficheroSalida = new BinaryWriter(File.Open(url, FileMode.Create));
                    for (int i = 0; i < lista.Count; i++)
                    {
                        person p = lista.ElementAt(i);

                        ficheroSalida.Write(p.id);
                        ficheroSalida.Write(p.nom);
                        ficheroSalida.Write(p.tel);
                    }
                    ficheroSalida.Close();
                    return 1;
                }
                catch (Exception ex)
                {
                    return 0;
                }
                
            }

            public List<person> leerArchivo(String url)
            {
                List<person> lista = new List<person>();
                BinaryReader ficheroEntrada;

                try
                {
                    ficheroEntrada = new BinaryReader(File.Open(url, FileMode.Open));
                    while (true)
                    {
                        person p = new person();
                        int id = ficheroEntrada.ReadInt32();
                        String nom = ficheroEntrada.ReadString();
                        int tel = ficheroEntrada.ReadInt32();
                        p.load(id,nom,tel);
                        lista.Add(p);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return lista;
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Archivo!=null)
            {
                llenarLista();

                f.EscribeArchivo(Archivo, lista);
            }
            else
            {
                guardarComo();
            }
            this.toolStripStatusLabel1.Text = "Se guardo correctamente";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Esta seguro que quiere salir de la app", "Informacion",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(dataGridView1.Rows.Count - 1 > 0)
            {
                if(e.ColumnIndex == dataGridView1.Columns.IndexOf(Eliminar))
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control.GetType()==typeof(DataGridViewTextBoxEditingControl))
            {
                TextBox t = (TextBox)e.Control;
                column = dataGridView1.CurrentCell.ColumnIndex;
                if (dataGridView1.CurrentCell.ColumnIndex ==0)
                {
                    t.KeyPress += new KeyPressEventHandler(t_keyPress);
                }
            }
        }
        private void t_keyPress(object sender,KeyPressEventArgs e)
        {
            if (column == 0 || column ==2)
            {
                if (char.IsNumber(e.KeyChar) || e.KeyChar ==(char)Keys.Back)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;   
                }
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}