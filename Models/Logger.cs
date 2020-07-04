using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5kaPP.Models
{
    //класс Logger, который записывает события либо ошибки в соответствующие файлы, в папке Logs
    public class Logger
    {
        private string logDirectory { get; set; }

        public Logger()
        {
            logDirectory = Program.appRoot + @"/_logs/" + DateTime.Now.ToString("dd-MM-yy HH-mm-ss") + @"/";

            if (!Directory.Exists(logDirectory))
                Directory.CreateDirectory(logDirectory);
        }

        public void Event(string _message) 
        {
            using (StreamWriter writetext = new StreamWriter(logDirectory + "events.txt"))
            {
                writetext.WriteLine(_message);
            }
        }

        public void Error() 
        {
            using (StreamWriter writetext = new StreamWriter("errors.txt"))
            {
                writetext.WriteLine("writing in text file");
            }
        }
    }
}
