using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Explorer
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			this.Icon = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 45);

			Icon ic0 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 7);
			TreeImageList.Images.Add(ic0);
			Icon ic1 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 8);
			TreeImageList.Images.Add(ic1);
			Icon ic2 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 9);
			TreeImageList.Images.Add(ic2);
			Icon ic3 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 11);
			TreeImageList.Images.Add(ic3);
			Icon ic4 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 15);
			TreeImageList.Images.Add(ic4);
			Icon ic5 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 3);
            TreeImageList.Images.Add(ic5);
            Icon ic6 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 4);
            TreeImageList.Images.Add(ic6);
			Icon ic7 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 31);
			TreeImageList.Images.Add(ic7);

			GetDrive();
            ListViewAB(1);
			this.treeView1.Select();
		}

		TreeNode CurrentNode;
		string strFilePath="";

		//把文件夹路径改为正确的格式
		private string CorrectPath(string strPath)
		{
			if (strPath.Substring(strPath.Length - 2, 1) == ":")
			{
				strPath = strPath.Substring(strPath.Length - 3, 2) + "\\";
			}
			else
			{
                int a = strPath.IndexOf("(") + 1;
                int b = strPath.IndexOf(")") + 1;
				strPath = strPath.Substring(a, 2) + strPath.Substring(b, strPath.Length - b);
			}
			return strPath;
		}

		//把文件路径改为正确的格式
		private string CorrectName(string strPath)
		{
			if (strPath.Substring(strPath.Length - 2, 1) == ":")
			{
				strPath = strPath.Substring(strPath.Length - 3, 2) + "\\";
			}
			return strPath;
		}

		//在右侧窗体显示磁盘分区
        private void ShowDrive()
        {
            this.LisrimageList2.Images.Clear();
            this.LisrimageList.Images.Clear();
            listView1.SmallImageList = LisrimageList;
            Icon ic0 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 7);
            Icon ic1 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 8);
            Icon ic2 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 9);
            Icon ic3 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 11);

            LisrimageList.Images.Add(ic0);
            LisrimageList.Images.Add(ic1);
            LisrimageList.Images.Add(ic2);
            LisrimageList.Images.Add(ic3);

            LisrimageList2.Images.Add(ic0);
            LisrimageList2.Images.Add(ic1);
            LisrimageList2.Images.Add(ic2);
            LisrimageList2.Images.Add(ic3);

            listView1.Clear();
            //设置列表框的表头
            listView1.Columns.Add("名称", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("类型", 140, HorizontalAlignment.Left);
            listView1.Columns.Add("总大小", 100, HorizontalAlignment.Right);
            listView1.Columns.Add("可用空间", 100, HorizontalAlignment.Right);
            listView1.Columns.Add("备注", 120, HorizontalAlignment.Left);

            int iItem = 0;
            int ico = 1;
            try
            {
                DriveInfo[] Drives = DriveInfo.GetDrives();
                foreach (DriveInfo str in Drives)
                {
                    string label;
                    string[] arrSubItem = new string[5];

                    if (str.DriveType == DriveType.Removable)
                    {
                        if (str.VolumeLabel.Length == 0)
                        {
                            label = "可移动磁盘";
                        }
                        else
                        {
                            label = str.VolumeLabel;
                        }

                        ico = 0;
                        label = label + " (" + str.ToString().Substring(0, 2) + ")";
                        arrSubItem[0] = label;
						arrSubItem[1] = "可移动磁盘";
						string[] ds = GetDriveSize(str);
						arrSubItem[2] = ds[0];
						arrSubItem[3] = ds[1];
                        arrSubItem[4] = "";
                    }
                    else  if (str.DriveType == DriveType.Fixed)
                    {
                        if (str.VolumeLabel.Length == 0)
                        {
                            label = "本地磁盘";
                        }
                        else
                        {
                            label = str.VolumeLabel;
                        }
                        ico = 1;
                        label = label + " (" + str.ToString().Substring(0, 2) + ")";
                        arrSubItem[0] = label;
						arrSubItem[1] = "本地磁盘";
						string[] ds = GetDriveSize(str);
						arrSubItem[2] = ds[0];
						arrSubItem[3] = ds[1];
                        arrSubItem[4] = "本机的固定磁盘";
                    }
                    else if (str.DriveType == DriveType.Network)
                    {
                        if (str.VolumeLabel.Length == 0)
                        {
                            label = "网络驱动器";
                        }
                        else
                        {
                            label = str.VolumeLabel;
                        }
                        ico = 2;
                        label = label + " (" + str.ToString().Substring(0, 2) + ")";
                        arrSubItem[0] = label;
						arrSubItem[1] = "网络驱动器";
						string[] ds = GetDriveSize(str);
						arrSubItem[2] = ds[0];
						arrSubItem[3] = ds[1];
                        arrSubItem[4] = "网络上的驱动器";
                    }
                    else if (str.DriveType == DriveType.CDRom)
                    {
                        ico = 3;
						if (str.IsReady == false)
						{
							label = "DVD 驱动器";
							label = label + " (" + str.ToString().Substring(0, 2) + ")";
							arrSubItem[0] = label;
							arrSubItem[1] = "CD 驱动器";
							arrSubItem[2] = "";
							arrSubItem[3] = "";
						}
						else
						{
							if (str.VolumeLabel.Length == 0)
							{
								label = "DVD 驱动器";
							}
							else
							{
								label = str.VolumeLabel;
							}
							label = label + " (" + str.ToString().Substring(0, 2) + ")";
							arrSubItem[0] = label;
							arrSubItem[1] = "CD 驱动器";
							string[] ds = GetDriveSize(str);
							arrSubItem[2] = ds[0];
							arrSubItem[3] = ds[1];
						}
						arrSubItem[4] = "";
                    }
                    else if (str.DriveType == DriveType.Unknown)
                    {
                        ico = 0;
                        label = str.VolumeLabel + str.ToString();
						label = str.ToString();
						arrSubItem[0] = label;
						arrSubItem[1] = "未知类型";
						arrSubItem[2] = "未知大小";
						arrSubItem[3] = "未知大小";
						arrSubItem[4] = "";
                    }
                    else
                    {
                        label = str.ToString();
                        arrSubItem[0] = label;
                        arrSubItem[1] = "未知类型";
                        arrSubItem[2] = "未知大小";
                        arrSubItem[3] = "未知大小";
                        arrSubItem[4] = "";
                    }

                    //以下是向列表框中插入驱动器。
                    ListViewItem LiItem = new ListViewItem(arrSubItem, ico);
                    listView1.Items.Insert(iItem, LiItem);
                    iItem++;
                }
                strFilePath = "";
				textBox1.Text = "我的电脑";
				this.statusBar1.Text = iItem.ToString() + " 个对象";
            }
            catch (IOException ex)
            { MessageBox.Show(ex.Message, "错误", 0, MessageBoxIcon.Error); return; }
        }

		//在左侧窗体添加所有磁盘分区
		private void GetDrive()
        {
            treeView1.ImageList = TreeImageList;

            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();

            TreeNode RootNode = new TreeNode("我的电脑", 4, 4);
            treeView1.Nodes.Add(RootNode);
            treeView1.SelectedNode = RootNode;
			
			CurrentNode = RootNode;
			RootNode.Expand();

            try
            {
                int iImageIndex;
                int iSelectedIndex;
                DriveInfo[] Drives = DriveInfo.GetDrives();
                foreach (DriveInfo str in Drives)
                {
                    string label;

                    if (str.DriveType == DriveType.Removable)
                    {
                        if (str.VolumeLabel.Length == 0)
                        {
                            label = "可移动磁盘";
                        }
                        else
                        {
                            label = str.VolumeLabel;
                        }
                        iImageIndex = 0;
                        iSelectedIndex = 0;
                        label = label + " (" + str.ToString().Substring(0, 2) + ")";
                    }
                    else if (str.DriveType == DriveType.Fixed)
                    {
                        if (str.VolumeLabel.Length == 0)
                        {
                            label = "本地磁盘";
                        }
                        else
                        {
                            label = str.VolumeLabel;
                        }
                        iImageIndex = 1;
                        iSelectedIndex = 1;
                        label = label + " (" + str.ToString().Substring(0, 2) + ")";
                    }
                    else if (str.DriveType == DriveType.Network)
                    {
                        if (str.VolumeLabel.Length == 0)
                        {
                            label = "网络驱动器";
                        }
                        else
                        {
                            label = str.VolumeLabel;
                        }
                        iImageIndex = 2;
                        iSelectedIndex = 2;
                        label = label + " (" + str.ToString().Substring(0, 2) + ")";
                    }
                    else if (str.DriveType == DriveType.CDRom)
                    {
						if (str.IsReady == false)
						{
							label = "DVD 驱动器";
						}
						else
						{
							if (str.VolumeLabel.Length == 0)
							{
								label = "DVD 驱动器";
							}
							else
							{
								label = str.VolumeLabel;
							}
						}
						iImageIndex = 3;
						iSelectedIndex = 3;
						label = label + " (" + str.ToString().Substring(0, 2) + ")";
                    }
                    else if (str.DriveType == DriveType.Unknown)
                    {
                        iImageIndex = 0;
                        iSelectedIndex = 0;
                        label = str.VolumeLabel + str.ToString();
                    }
                    else
                    {
                        iImageIndex = 0;
                        iSelectedIndex = 0;
                        label = str.ToString();
                    }
                    TreeNode tnDrive = new TreeNode(label, iImageIndex, iSelectedIndex);
                    treeView1.Nodes[0].Nodes.Add(tnDrive);
                    AddDirectories(tnDrive);
                }
            }
            catch (IOException ex)
            { MessageBox.Show(ex.Message, "错误", 0, MessageBoxIcon.Error); return; }

            ShowDrive();

            treeView1.EndUpdate();
        }

		//获得磁盘分区的总大小和可用空间
		private string[] GetDriveSize(DriveInfo str)
		{
			string[] DS = new string[2];

			//获得磁盘分区的总大小
			if (str.TotalSize == 0)
			{
				DS[0] = "0 字节";
			}
			else
				if (str.TotalSize < 1024)
				{
					DS[0] = str.TotalSize.ToString() + " 字节";
				}
				else
					if (str.TotalSize < 1048576)
					{
						string a = (float.Parse(str.TotalSize.ToString()) / 1024).ToString();
						if (a.IndexOf(".") == -1)
						{
							DS[0] = a + " KB";
						}
						else
						{
							DS[0] = a.Substring(0, a.LastIndexOf(".")) + " KB";
						}
					}
					else if (str.TotalSize < 1073741824)
					{
						string a = (float.Parse(str.TotalSize.ToString()) / 1048576).ToString();
						if (a.IndexOf(".") == -1)
						{
							DS[0] = a + " MB";
						}
						else
						{
							DS[0] = a.Substring(0, a.LastIndexOf(".")) + " MB";
						}
					}
					else
					{
						string a = (float.Parse(str.TotalSize.ToString()) / 1073741824).ToString();
						if (a.IndexOf(".") == -1)
						{
							DS[0] = a + " GB";
						}
						else
						{
							DS[0] = a.Substring(0, 4) + " GB";
						}
					}

			//获得磁盘分区的可用空间
			if (str.TotalFreeSpace == 0)
			{
				DS[1] = "0 字节";
			}
			else
				if (str.TotalFreeSpace < 1024)
				{
					DS[1] = str.TotalFreeSpace.ToString() + " 字节";
				}
				else
					if (str.TotalFreeSpace < 1048576)
					{
						string b = (float.Parse(str.TotalFreeSpace.ToString()) / 1024).ToString();
						if (b.IndexOf(".") == -1)
						{
							DS[1] = b + " KB";
						}
						else
						{
							DS[1] = b.Substring(0, b.LastIndexOf(".")) + " KB";
						}
					}
					else if (str.TotalFreeSpace < 1073741824)
					{
						string b = (float.Parse(str.TotalFreeSpace.ToString()) / 1048576).ToString();
						if (b.IndexOf(".") == -1)
						{
							DS[1] = b + " MB";
						}
						else
						{
							DS[1] = b.Substring(0, b.LastIndexOf(".")) + " MB";
						}
					}
					else
					{
						string b = (float.Parse(str.TotalFreeSpace.ToString()) / 1073741824).ToString();
						if (b.IndexOf(".") == -1)
						{
							DS[1] = b + " GB";
						}
						else
						{
							DS[1] = b.Substring(0, 4) + " GB";
						}
					}
			return DS;
		}

		//*************************************************************************************
		[DllImport("Shell32.dll")] 
		public static extern int ExtractIcon(IntPtr h,string strx,int ii);

		[DllImport("Shell32.dll")] 
		public static extern int SHGetFileInfo(string pszPath,uint dwFileAttributes,ref SHFILEINFO psfi,uint cbFileInfo, uint uFlags);

		public struct SHFILEINFO
		{ 
			public IntPtr hIcon;  
			public int   iIcon;  
			public uint dwAttributes;
			public char szDisplayName; 
			public char szTypeName; 
		}

		//*************************************************************************************
		protected virtual Icon myExtractIcon(string FileName,int iIndex)
		{
			try
			{
				IntPtr hIcon=(IntPtr)ExtractIcon(this.Handle,FileName,iIndex);
				if(! hIcon.Equals(null))
				{
					Icon icon=Icon.FromHandle(hIcon);
					return icon;
				}
			}
			catch(Exception ex)
			{ MessageBox.Show(ex.Message,"错误",0,MessageBoxIcon.Error);} 
			return null;
		}

		//*************************************************************************************
		protected virtual void SetIcon(ImageList imageList,string FileName,bool tf)
		{
			SHFILEINFO fi=new SHFILEINFO();
			if(tf==true)
			{
				int iTotal=(int)SHGetFileInfo(FileName,0,ref fi,100,  16640);//SHGFI_ICON|SHGFI_SMALLICON
				try
				{
					if(iTotal >0)
					{
						Icon ic=Icon.FromHandle(fi.hIcon);
						imageList.Images.Add(ic);
						//return ic;
					}
				}
				catch(Exception ex)
				{ MessageBox.Show(ex.Message, "错误", 0, MessageBoxIcon.Error); return; } 
			}
			else
			{
				int iTotal=(int)SHGetFileInfo(FileName,0,ref fi,100,  257);
				try
				{
					if(iTotal >0)
					{
						Icon ic=Icon.FromHandle(fi.hIcon);
						imageList.Images.Add(ic);
						//return ic;
					}
				}
				catch(Exception ex)
				{ MessageBox.Show(ex.Message, "错误", 0, MessageBoxIcon.Error); return; } 
			}
			// return null;
		}

		//在左侧窗体添加文件夹树
		private void AddDirectories(TreeNode tn)
		{
			tn.Nodes.Clear();

			string strPath=tn.FullPath;
			strPath=strPath.Remove(0,5);
			strPath = CorrectPath(strPath);

			//获得当前目录
			DirectoryInfo dirinfo = new DirectoryInfo(strPath);
			DirectoryInfo[] adirinfo;
			try
			{adirinfo = dirinfo.GetDirectories();}
			catch
			{ return;}

			int iImageIndex=5;  int iSelectedIndex=5;
			foreach (DirectoryInfo di in adirinfo)
			{
				if(di.Name=="RECYCLER"||di.Name=="RECYCLED"||di.Name=="Recycled")
				{iImageIndex=7;  iSelectedIndex=7;}
				else 
				{iImageIndex=5;  iSelectedIndex=5;}

				TreeNode tnDir = new TreeNode(di.Name, iImageIndex, iSelectedIndex);
				tn.Nodes.Add(tnDir);
			}


			/*
			//获得当前目录下的所有文件 
			FileInfo[] dirFiles;
			dirFiles=dirinfo.GetFiles();
			int iCount=7;

			foreach (FileInfo fi in dirFiles)
			{
				//得到每个文件的图标
				string str=fi.FullName;
				try
				{
					SetIcon(TreeImageList,str,false);
				}
				catch(Exception ex)
				{ MessageBox.Show(ex.Message,"错误",0,MessageBoxIcon.Error);}
				    
				TreeNode tnDir = new TreeNode(fi.Name, iCount, iCount);
				tn.Nodes.Add(tnDir);

				iCount++;
			}
			*/
		}

		//切换右侧窗体排列方式
		protected virtual void ListViewAB(int iii)
		{
			if(iii==1)
			{
				LisrimageList2.ImageSize=new Size(32,32);
				listView1.LargeImageList=LisrimageList2;

				if(listView1.View==View.Details||listView1.View==View.SmallIcon)
				{listView1.View=View.LargeIcon;}
			}
			else if(iii==2)
			{
				if(listView1.View==View.Details||listView1.View==View.LargeIcon)
				{listView1.View=View.SmallIcon;}
			}
			else
			{
				if(listView1.View==View.LargeIcon||listView1.View==View.SmallIcon)
				{listView1.View=View.Details;}
			}
		}

		//*************************************************************************************
		private void treeView1_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			//base.OnBeforeExpand(e);

			treeView1.BeginUpdate();

			foreach (TreeNode tn in e.Node.Nodes)
			{ AddDirectories(tn);}

			treeView1.EndUpdate();
		}

		//*************************************************************************************
		protected virtual void InitList(TreeNode tn)
		{
			bool flag = true;
			string strPath = tn.FullPath;
			strPath = strPath.Remove(0, 5);
			strPath = CorrectPath(strPath);

			if (strPath.Substring(strPath.Length - 2, 1) == ":")
			{
				DriveInfo di = new DriveInfo(strPath);
				if (di.IsReady == false)
				{
					flag = false;
					if (di.DriveType == DriveType.CDRom)
					{ MessageBox.Show("请将光盘插入驱动器 " + strPath + "。", "插入光盘", 0, MessageBoxIcon.Information); }
					else
					{ MessageBox.Show("驱动器未准备好！请稍后再试。"); }
					return;
				}
			}

			this.statusBar1.Text="正在刷新文件夹，请稍等.....";
			treeView1.BeginUpdate();
			this.Cursor=Cursors.WaitCursor;

			this.LisrimageList.Images.Clear();
			this.LisrimageList2.Images.Clear();
			listView1.SmallImageList=LisrimageList;
			Icon ic0=myExtractIcon("%SystemRoot%\\system32\\shell32.dll",3);
			LisrimageList.Images.Add(ic0);
			LisrimageList2.Images.Add(ic0);

			listView1.Clear();
			//设置列表框的表头
			listView1.Columns.Add("文件名",160,HorizontalAlignment.Left);
			listView1.Columns.Add("文件大小",120,HorizontalAlignment.Right);
			listView1.Columns.Add("创建时间",120,HorizontalAlignment.Left);
			listView1.Columns.Add("访问时间",120,HorizontalAlignment.Left);

			//以下是向列表框中插入目录，不是文件。获得当前目录下的各个子目录。
			int iItem=0;

			DirectoryInfo Dir=new DirectoryInfo(strPath);
			try
			{
				foreach (DirectoryInfo di in Dir.GetDirectories())
				{
					ListViewItem LiItem = new ListViewItem(di.Name, 0);
					listView1.Items.Insert(iItem, LiItem);
					iItem++;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "错误", 0, MessageBoxIcon.Error);
				this.statusBar1.Text = "就绪";
				this.Cursor = Cursors.Arrow;
				treeView1.EndUpdate();
				return;
			}

			//获得当前目录下的所有文件
			DirectoryInfo curDir=new DirectoryInfo(strPath);//创建目录对象。
			FileInfo[] dirFiles;
			try
			{
				dirFiles=curDir.GetFiles();
			}
			catch
			{
				this.statusBar1.Text = "就绪";
				this.Cursor = Cursors.Arrow;
				treeView1.EndUpdate();
				return;
			}

			string []arrSubItem=new string[4];
			//文件的创建时间和访问时间。
			int iCount=0;    int iconIndex=1;//用1，而不用0是要让过0号图标。
			foreach(FileInfo fileInfo in dirFiles)
			{
				string strFileName=fileInfo.Name;           
				        
				//如果不是文件pagefile.sys
				//if(! strFileName.Equals("pagefile.sys"))
				//{
					arrSubItem[0]=strFileName;
					arrSubItem[1]=fileInfo.Length+" 字节";
					arrSubItem[2]=fileInfo.CreationTime.ToString();
					arrSubItem[3]=fileInfo.LastAccessTime.ToString();
				//}
				//else
				//{arrSubItem[1]="未知大小"; arrSubItem[2]="未知日期"; arrSubItem[3]="未知日期";}


				//得到每个文件的图标
				string str=fileInfo.FullName;
				try
				{
					SetIcon(LisrimageList,str,false);
					SetIcon(LisrimageList2,str,true);
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message, "错误提示", 0, MessageBoxIcon.Error);
					this.statusBar1.Text = "就绪";
					this.Cursor = Cursors.Arrow;
					treeView1.EndUpdate(); 
					return;
				}

				//插入列表项    
				ListViewItem LiItem=new ListViewItem(arrSubItem,iconIndex);
				listView1.Items.Insert(iCount,LiItem);

				iCount++; 
				iconIndex++;
			}
			treeView1.EndUpdate();

			strFilePath=strPath;
			textBox1.Text=strPath;
			int iTotal = iItem + iCount;
			this.statusBar1.Text = iTotal + " 个对象：（" + iItem.ToString() + " 个文件夹，" + iCount.ToString() + " 个文件）";
			this.Cursor = Cursors.Arrow;
            strFilePath = strPath;
		} 

		//*************************************************************************************
		protected virtual void InitList2(string strName)
		{
			this.statusBar1.Text = "正在刷新文件夹，请稍等.....";
			listView1.BeginUpdate();
			this.Cursor=Cursors.WaitCursor;

			this.LisrimageList.Images.Clear();
			this.LisrimageList2.Images.Clear();
			listView1.SmallImageList=LisrimageList;
			Icon ic0 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 3);
			LisrimageList.Images.Add(ic0);
			LisrimageList2.Images.Add(ic0);
			strName = CorrectName(strName);

			listView1.Clear();
			//设置列表框的表头
			listView1.Columns.Add("文件名",160,HorizontalAlignment.Left);
			listView1.Columns.Add("文件大小",120,HorizontalAlignment.Left);
			listView1.Columns.Add("创建时间",120,HorizontalAlignment.Left);
			listView1.Columns.Add("访问时间",120,HorizontalAlignment.Left);

			//以下是向列表框中插入目录，不是文件。获得当前目录下的各个子目录。
			int iItem=0;//调用listView1.Items.Insert(iItem,LiItem);时用。不能使用iconIndex。

			try
			{
				DirectoryInfo Dir = new DirectoryInfo(strName);//创建目录对象。
				foreach (DirectoryInfo di in Dir.GetDirectories())
				{
					ListViewItem LiItem = new ListViewItem(di.Name, 0);
					listView1.Items.Insert(iItem, LiItem);
					iItem++;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "错误", 0, MessageBoxIcon.Error);
				this.statusBar1.Text = "就绪";
				this.Cursor = Cursors.Arrow;
				listView1.EndUpdate();
				return;
			}

			//获得当前目录下的所有文件 
			DirectoryInfo curDir=new DirectoryInfo(strName);//创建目录对象。
			FileInfo[] dirFiles;
			try
			{
				dirFiles=curDir.GetFiles();
			}
			catch
			{
				listView1.EndUpdate();
				this.statusBar1.Text = "就绪";
				this.Cursor = Cursors.Arrow;
				listView1.EndUpdate();
				return;
			}

			string []arrSubItem=new string[4];
			//文件的创建时间和访问时间。
			int iCount=0;    int iconIndex=1;//用1，而不用0是要让过0号图标。
			foreach(FileInfo fileInfo in dirFiles)
			{
				string strFileName=fileInfo.Name;           
				        
				//如果不是文件pagefile.sys
				//if(! strFileName.Equals("pagefile.sys"))
				//{
					arrSubItem[0]=strFileName;
					arrSubItem[1]=fileInfo.Length+" 字节";
					arrSubItem[2]=fileInfo.CreationTime.ToString();
					arrSubItem[3]=fileInfo.LastAccessTime.ToString();
				//}
				//else
				//{ arrSubItem[1]="未知大小"; arrSubItem[2]="未知日期"; arrSubItem[3]="未知日期";}


				//得到每个文件的图标
				string str=fileInfo.FullName;
				try
				{
					SetIcon(LisrimageList,str,false);
					SetIcon(LisrimageList2,str,true);
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message, "错误", 0, MessageBoxIcon.Error);
					this.statusBar1.Text = "就绪";
					this.Cursor = Cursors.Arrow;
					listView1.EndUpdate();
					return;
				}
				    
				//插入列表项    
				ListViewItem LiItem=new ListViewItem(arrSubItem,iconIndex);
				listView1.Items.Insert(iCount,LiItem);

				iCount++; 
				iconIndex++;//必须加在listView1.Items.Insert(iCount,LiItem);
			}
			listView1.EndUpdate();
			strFilePath=strName;//把路径赋值于全局变量strFilePath

			textBox1.Text=strName;
			int iTotal = iItem + iCount;
			this.statusBar1.Text = iTotal + " 个对象：（" + iItem.ToString() + " 个文件夹，" + iCount.ToString() + " 个文件）";
			this.Cursor=Cursors.Arrow;
		} 

		//*************************************************************************************
		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Node.Text == "我的电脑")
            {
				CurrentNode = e.Node;
				ShowDrive();
				return;
			}
			//e.Node.Expand();
			CurrentNode = e.Node;
			InitList(e.Node);
		}

		//*************************************************************************************
		void treeView1_NodeMouseClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
		{
			if (e.Node.IsExpanded == false)
			{
				//e.Node.Expand();
			}
		}

		//*************************************************************************************
		private void button1_Click(object sender, System.EventArgs e)
		{
            menuItem3_Click(null,null);
		}

		//*************************************************************************************
		private void listView1_DoubleClick(object sender, System.EventArgs e)
		{
			string node = listView1.FocusedItem.Text;
			string str = Path.Combine(strFilePath, CorrectName(node));
            try
            {
                bool di = new DirectoryInfo(str).Exists;
                if (di==false)
                { System.Diagnostics.Process.Start(str); }
                else
                {
                    InitList2(str);
					foreach(TreeNode tn in CurrentNode.Nodes)
					{
						if (tn.Text == node)
						{
							CurrentNode = tn;
							break;
						}
					}
					treeView1.SelectedNode = CurrentNode;
					CurrentNode.Expand();

                }
            }
            catch { return; }
		}

		//*************************************************************************************
		private void menuItem3_Click(object sender, System.EventArgs e)
		{
            this.menuItem3.Checked = this.splitContainer1.Panel1.Visible = !splitContainer1.Panel1.Visible;
		}

		//*************************************************************************************
		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			ListViewAB(1);
		}

		//*************************************************************************************
		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			ListViewAB(2);
		}

		//*************************************************************************************
		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			ListViewAB(3);
		}

		//*************************************************************************************
		private void menuItem8_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void menuItem19_Click(object sender, EventArgs e)
        {
            AboutBox abx = new AboutBox();
            abx.ShowDialog();
        }
	}
}
