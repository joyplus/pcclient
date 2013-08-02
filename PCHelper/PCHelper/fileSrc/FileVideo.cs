#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

using System.IO;
using System.Drawing;

namespace System.Windows.Forms.Samples
{
    public class FileVideo
    {
        private string _path;
        private string _name;
        private long _size;
        private int _videoNum;
        private bool _converterState;
        //private DateTime _modified;
        //private DateTime _created;
        private string _type;
        private Icon _icon;

        public FileVideo(string path) : this(new FileInfo(path)) { }

        public FileVideo(FileSystemInfo fileInfo)
        {
            SetState(fileInfo);
        }

        public bool IsDirectory
        {
            get { return (_size == -1); }
        }

        private void SetState(FileSystemInfo fileInfo)
        {
            _path = fileInfo.FullName;
            _name = fileInfo.Name;
            _converterState = false;
            // Check if not a directory (size is not valid)
            if (fileInfo is FileInfo)
            {
                _size = (fileInfo as FileInfo).Length;
            }
            else
            {
                _size = -1;
            }

            //_modified = fileInfo.LastWriteTime;
            //_created = fileInfo.CreationTime;

            // Get Type Name
            Win32.SHFILEINFO info = Win32.ShellGetFileInfo.GetFileInfo(fileInfo.FullName);

            _type = info.szTypeName;

            // Get ICON
            _icon = System.Drawing.Icon.FromHandle(info.hIcon);
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public long Size
        {
            get { return _size; }
        }

        public int VideoNum
        {
            get { return _videoNum;  }
        }

        public bool ConverterState
        {
            get { return _converterState; }
        }

        /*public DateTime DateModified
        {
            get { return _modified; }
        }

        public DateTime DateCreated
        {
            get { return _created; }
        }*/

        public string Type
        {
            get { return _type; }
        }

        public Icon Icon
        {
            get { return _icon; }
        }

        public void Update()
        {
            // Reset state
            SetState(new FileInfo(_path));
        }

        public string FullName
        {
            get { return _path; }
        }

        public void Update(FileSystemInfo fsi)
        {
            // Reset state - name changed
            SetState(fsi);
        }
    }
}
