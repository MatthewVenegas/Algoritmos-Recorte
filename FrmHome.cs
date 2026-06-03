using System;
using System.Windows.Forms;

namespace AlgoritmosDeDiscretizacion
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
            IsMdiContainer = true;
            
            // Open the Lineas form by default
            this.Load += (s, e) => ShowForm<FrmLineas>();
        }

        private void ShowForm<T>() where T : Form, new()
        {
            // Close existing children to avoid overlaps
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }

            T frm = new T();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void lineasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<FrmLineas>();
        }

        private void circulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<FrmCirculos>();
        }

        private void rellenoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm<FrmPixelEditor>();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {

        }
    }
}
