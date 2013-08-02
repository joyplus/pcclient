#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Samples;
using PCHelper.src;

#endregion

namespace PCHelper
{
    public partial class ScanForm : Form
    {
        private DirectoryVideo _dir;
        
        public ScanForm()
        {
            InitializeComponent();
        }
        
        #region Helper Methods
        
        private void SetTitle(FileVideo fv)
        {
            // Clicked on the Name property, update the title
            this.Text = fv.Name;
            this.Icon = fv.Icon;
        }

        private bool DoActionRequired(object sender)
        {
            ToolStripMenuItem item = (sender as ToolStripMenuItem);
            bool doAction;

            // Clear other items
            //ClearItems(item);

            // Check this one
            if (!item.Checked)
            {
                item.Checked = true;
                doAction = false;
            }
            else
            {
                // Item click and wasn't previously checked - Do action
                doAction = true;
            }

            return doAction;
        }
        #endregion

        #region Event Handlers
        private void ExplorerView_Load(object sender, EventArgs e)
        {
            // Set Initial Directory to My Documents
            _dir = new DirectoryVideo();
            this.FileViewBindingSource.DataSource = _dir;

            // Set the title
            SetTitle(_dir.FileVideo);

            // Set Size column to right align
            DataGridViewColumn col = this.dataGridView1.Columns["PathCol"];

            if (null != col)
            {
                DataGridViewCellStyle style = col.HeaderCell.Style;

                style.Padding = new Padding(style.Padding.Left, style.Padding.Top, 6, style.Padding.Bottom);
                style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Select first item
            col = this.dataGridView1.Columns["Name"];

            if (null != col)
            {
                this.dataGridView1.Rows[0].Cells[col.Index].Selected = true;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "PathCol")
            {
                e.Value = "C:\\Document";
            }
            else if (this.dataGridView1.Columns[e.ColumnIndex].Name == "VideoNumCol")
            {
                e.Value = "7";
            }

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Icon icon = (e.Value as Icon);

            if (null != icon)
            {
                using (SolidBrush b = new SolidBrush(e.CellStyle.BackColor))
                {
                    e.Graphics.FillRectangle(b, e.CellBounds);
                }

                // Draw right aligned icon (1 pixed padding)
                e.Graphics.DrawIcon(icon, e.CellBounds.Width - icon.Width - 1, e.CellBounds.Y + 1);
                e.Handled = true;
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Call Active on DirectoryView
            try
            {
                _dir.Activate(this.FileViewBindingSource[e.RowIndex] as FileVideo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        #endregion

    }
}
