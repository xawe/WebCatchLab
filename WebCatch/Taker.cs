﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebCatch
{
    /// <summary>
    /// Download data from specified links
    /// </summary>
    public class Taker
    {
        public void DownloadItems(List<EntityModel.References> links, string pathToSave, string extension)
        {
            if (links.Any())
            {
                List<Task> tasks = new List<Task>();
                links.ForEach(item => {                    
                    var task = new Task(() => { DownloadData(item.Url, GetFileName(pathToSave, item.Id.ToString(), extension)); });
                    task.Start();
                    tasks.Add(task);                    
                });

                Task.WaitAll(tasks.ToArray());
            }
        }

        private string GetFileName(string path, string id, string extension)
        {
            return String.Format("{0}\\{1}{2}", path, id, extension);
        }
        private void DownloadData(string url, string fileName)
        {
            WebClient myWebClient = new WebClient();
            myWebClient.DownloadFile(url, fileName);
        }
    }
}
