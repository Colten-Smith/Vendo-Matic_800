using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class FileReader
    {
        private string FilePath { get; set; }

        public FileReader(string filePath)
        {
            FilePath = filePath;
        }
        public List<string[]> GetItemsFromFile()
        {
            List<string[]> output = new List<string[]>();
            try
            {
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] item = line.Split('|');
                        output.Add(item);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return output;
        }
    }
}
