using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCHelper.fileSrc
{
    class VideoFileInfo
    {
        private string name;
        private string path;
        private int num;
        private Boolean converter;

        public VideoFileInfo()
        {

        }

        public VideoFileInfo(string name)
        {
            this.name = name;
        }

        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return this.name;
        }
        public void setPath(string path)
        {
            this.path = path;
        }
        public string getPath()
        {
            return this.path;
        }
        public void setNum(int num)
        {
            this.num = num;
        }
        public int getNum()
        {
            return this.num;
        }
        public void setConverter ( Boolean converter )
        {
            this.converter = converter;
        }
        public Boolean getConverter()
        {
            return this.converter;
        }
    }
}
