using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public int ChildIndex { get; private set; }

        public MainForm()
        {
            InitializeComponent();
        }
#region MainForm_Events
        private void Birth_Child(object sender, EventArgs e)
        {
            ChildForm CF= new ChildForm();
            CF.Text ="Child "+(++ChildIndex).ToString();
            CF.MdiParent = this;
            CF.Show();
        }
        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                Control ctrl=GetChildAtPoint(e.Location);
                if (ctrl != null)
                {
                    ItemConextMenu.Show(this,e.Location);
                    ItemConextMenu.CurrentItem = ctrl;
                    ItemConextMenu.Items[2].Enabled = true;
                    ItemConextMenu.Items[1].Enabled = false;
                }
            }
        }
#endregion
#region Control_Events
    #region All
        private void Show_All_Items(object sender, EventArgs e)
        {
            
            foreach (Control item in Controls)
            {

                item.Visible = true;
            }
        }
        private void Hide_All_Items(object sender, EventArgs e)
        {
            TableForm TF= new TableForm();
            foreach (Control item in Controls)
            {
                if(item is ToolStrip)
                {
                    continue;
                }
                item.Visible = false;
            }
        }
        private void Enable_All_Items(object sender, EventArgs e)
        {
            foreach (Control item in Controls)
            {
                item.Enabled = true;
            }
        }
        private void Disable_All_Items(object sender, EventArgs e)
        {
            foreach (Control item in Controls)
            {
                item.Enabled = false;
            }
        }
    #endregion
    #region Singular
        private void Item_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                ItemConextMenu.CurrentItem = sender as Control;
                    ItemConextMenu.Items[2].Enabled=false;
                    ItemConextMenu.Items[1].Enabled = true;
            }
        }
        private void Hide_Item(object sender, EventArgs e)
        {
            ItemConextMenu.CurrentItem.Visible = false;
        }
        private void Disable_Item(object sender, EventArgs e)
        {
            ItemConextMenu.CurrentItem.Enabled = false;
        }
        private void Enable_Item(object sender, EventArgs e)
        {
            ItemConextMenu.CurrentItem.Enabled = true;
        }
        #endregion

        #endregion

        private void birthFreeChildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm CF=new ChildForm();
            CF.Text = "Child " + (++ChildIndex).ToString();
            CF.Show();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if(ActiveMdiChild !=null)
            ActiveMdiChild.Close();
        }

        private void alignHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void alignVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void alignCascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Close();
        }
    }
}
