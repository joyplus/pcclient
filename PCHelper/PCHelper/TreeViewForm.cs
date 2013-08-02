using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Globalization;
using System.Runtime.InteropServices;
using System.IO;
using PCHelper.src;
using System.Windows.Forms.Samples;
using PCHelper.fileSrc;


namespace PCHelper
{
    public partial class TreeViewForm : Form
    {
        private string name = null;
        private string path = null;
        private Boolean addFlag = false;

        public TreeViewForm ( )
        {
            InitializeComponent ( );
        }

        private void TreeViewForm_Load ( object sender, EventArgs e )
        {
            LoadListView ( );
        }

        protected void LoadListView()
        {
            listView1.Clear();

            //创建ListView的标题列
            listView1.Columns.Add("Name", 75, System.Windows.Forms.HorizontalAlignment.Left);
            listView1.Columns.Add("Path", 150, System.Windows.Forms.HorizontalAlignment.Left);
        }

        private void AddBtn_Click ( object sender, EventArgs e )
        {
            string[] listviewData = new string[2];
            this.LoadListView ( );
            addFlag = false;
            VideoFileInfo videoFileInfo = new VideoFileInfo ( Const.videoName );
            videoFileInfo.setPath ( Const.videoPath );
            for(int j = 0;j<Const.fileArrayList.Count;j++)
            {
                if (((VideoFileInfo)Const.fileArrayList[j]).getName().Equals(videoFileInfo.getName()))
                {
                    addFlag = true;
                }
            }
            if (!addFlag)
            {
                Const.fileArrayList.Add ( videoFileInfo );
            }
            ListViewItem[] lvItem = new ListViewItem[Const.fileArrayList.Count];
            for (int i = 0; i < Const.fileArrayList.Count;i++ )
            {
                listviewData[0] = ((VideoFileInfo)Const.fileArrayList[i]).getName();
                listviewData[1] = ((VideoFileInfo)Const.fileArrayList[i]).getPath();
                lvItem[i] = new ListViewItem ( listviewData, i);
                listView1.Items.Add ( lvItem[i] );
            } 
        }

        private void DelBtn_Click ( object sender, EventArgs e )
        {
            LoadListView ( );
        }

        private void SubmmitBtn_Click ( object sender, EventArgs e )
        {
            /*
             *确认提交分享目录 
             */
            this.Close ( );
        }

        private void CancelBtn_Click ( object sender, EventArgs e )
        {
            this.Close ( );
        }

        private void listView1_MouseClick ( object sender,  MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                MessageBox.Show ( "ddd" );
            }
        }

        /*
         *treeview afterCheck
         */
        private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            //TreeNode nodeCurrent = e.Node;
            //nodeCurrent.Nodes.Clear();
            //if (nodeCurrent.SelectedImageIndex == 0)
               
            //else
            //    LoadDirectory(nodeCurrent, nodeCurrent.Nodes);
            //this.Cursor = Cursors.Default;
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node != null)
            {
                name = e.Node.Text;
                path = FormatPath(e.Node.FullPath);
            }
        }

        protected void LoadDirectory(TreeNode nodeCurrent, TreeNodeCollection nodeCurrentCollection)
        {
            TreeNode nodeTemp = null;

            int imageIndex = 2;	//当前结点的图片	
            int selectIndex = 3;	//选中结点时显示的图片

            if (nodeCurrent.SelectedImageIndex != 0)
            {
                try
                {
                    if (Directory.Exists(FormatPath(nodeCurrent.FullPath)) == false)
                        throw new Exception("目录或路路径不存在!");

                    LoadFiles(nodeCurrent);

                    string[] stringDirectories = Directory.GetDirectories(FormatPath(nodeCurrent.FullPath));
                    string stringFullPath = "";
                    string stringPathName = "";

                    //加载当前目录下所有子目录
                    foreach (string stringDir in stringDirectories)
                    {
                        stringFullPath = stringDir;
                        stringPathName = GetPathName(stringFullPath);

                        TreeNode nodeDir = new TreeNode(stringPathName.ToString(), imageIndex, selectIndex);
                        nodeCurrentCollection.Add(nodeDir);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        protected string GetPathName(string stringPath)
        {
            string[] stringSplit = stringPath.Split('\\');
            return stringSplit[stringSplit.Length - 1];
        }

        //替代Root是My Computer
        protected string FormatPath(string stringPath)
        {
            string stringParse = stringPath.Replace("My Computer\\", "");
            return stringParse;
        }

        //加载当前目录下的文件
        protected void LoadFiles(TreeNode nodeCurrent)
        {
            string[] listviewData = new string[2];
            this.LoadListView();

            if (nodeCurrent.SelectedImageIndex != 0)
            {
                if (Directory.Exists((string)FormatPath(nodeCurrent.FullPath)) == false)
                    throw new Exception("目录或路路径不存在!");
                try
                {
                    string[] stringFiles = Directory.GetFiles(FormatPath(nodeCurrent.FullPath));
                    foreach (string stringFile in stringFiles)
                    {
                        FileInfo objFileSize = new FileInfo(stringFile);          
                        listviewData[0] = objFileSize.Name;
                        listviewData[1] = GetPathName(stringFile);

                        ListViewItem lvItem = new ListViewItem(listviewData, 0);
                        listView1.Items.Add(lvItem);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

    }
}
