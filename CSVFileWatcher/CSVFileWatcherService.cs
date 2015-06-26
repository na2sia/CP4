using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
//using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using BLL;

namespace CSVFileWatcher
{
    public partial class CSVFileWatcherService : ServiceBase
    {
        private FileSystemWatcher fileWatcher;
        
        public string Directory { get; set; }
       
        public string FilesMask { get; set; }

        public CSVFileWatcherService()
        {
            InitializeComponent();
        }

        public void Start()
        {
            Console.WriteLine("start");

            try
            {
                this.fileWatcher = new FileSystemWatcher(Directory, FilesMask);
                this.fileWatcher.Created += OnFileCreate;
                this.fileWatcher.EnableRaisingEvents = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        //Processing of an event of creation of the new file
        private void OnFileCreate(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File of processing:" + e.FullPath);
            if (File.Exists(e.FullPath))
            {
                Task.Factory.StartNew(ProcessDataFile, e.FullPath);
            }
        }
        //Processing of the new file
        private void ProcessDataFile(object parameters)
        {
            if (parameters is string)
            {
                string fileName = parameters as string;
                Parser parser = new Parser();
                try
                    {
                        parser.ParseList(fileName);
                        Console.WriteLine("File " + fileName + " is processed");
                    }
                catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
            }
        }
        protected override void OnStart(string[] args)
        {
            this.Start();
        }

        protected override void OnStop()
        {
            this.fileWatcher.EnableRaisingEvents = false;
            this.fileWatcher.Dispose();
        }
    }
}
