using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class LogManager
    {
        private string FilePath { get; set; }
        public LogManager(string filePath)
        {
            FilePath = filePath;
        }
        public void LogTransaction(string type, decimal difference, decimal balance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FilePath, true))
                {
                    sw.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")} {type} ${difference} ${balance}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
