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



namespace Seira
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
             
        
        private void OpenBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog Open = new OpenFileDialog();
            Open.Title  = ("Open data source");
            Open.Filter = ("Text with delimiter .txt |*txt|Dat File .dat |*.dat");
            Open.ShowDialog();
            MessageBox.Show(Open.FileName);

            string A = Open.FileName;
            var B = File.ReadAllLines(A);
            var C = (from i in B select i.Split('\t')).ToArray();
            var D = (from j in C select j.Count()).Max();
            var table = new DataTable();

            table.Columns.AddRange(new DataColumn[] { new DataColumn("No"), new DataColumn("Dist (m)"), new DataColumn("Tap"), new DataColumn("Tbp") });
            StreamReader Data = new StreamReader(A);
            string all = Data.ReadToEnd();
            string[] nv = all.Split('\n');
            double[] No = new Double[nv.Length];
            double[] S  = new Double[nv.Length];
            double[] Ta = new Double[nv.Length];
            double[] Tb = new Double[nv.Length];

            for (int i=0; i<nv.Length; i++)
            {
                string[] allarray = nv[i].Split('\t');
                No[i] = Convert.ToDouble(allarray[0]);
                S[i]  = Convert.ToDouble(allarray[1]);
                Ta[i] = Convert.ToDouble(allarray[2]);
                Tb[i] = Convert.ToDouble(allarray[3]);

                object[] row = { No[i], S[i], Ta[i], Tb[i] };
                table.Rows.Add(row);
            }
            dataGridView1.DataSource = table;              
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Calculate_Click(object sender, EventArgs e)
        {
           

        }
    }
}
