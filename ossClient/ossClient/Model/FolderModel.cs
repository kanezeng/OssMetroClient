﻿using Oss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OssClientMetro.Model
{
    public class FolderModel : ObjectModel
    {
        public List<FileModel> objList { get; set; }
        public List<FolderModel> folderList { get; set; }


        override public void callback(HttpProcessData httpProcessData)
        {
            if (httpProcessData.ProgressPercentage == 100)
            {
                factory.StartNew((stateobj) =>
                {
                    HttpProcessData data = (HttpProcessData)stateobj;
                    ProcessSize += (long)data.TotalBytes;
                    Percent = (int)(1.0 * ProcessSize / Size);
                }, httpProcessData);
            }
        }

        //public List<OssObjectSummary> objList2 { get; set; }
        //public List<string> CommonPrefixes2 { get; set; }

    }
}
