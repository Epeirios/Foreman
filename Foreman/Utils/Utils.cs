using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreman
{
    public static class Utils
    {
        public static bool ReadJsonFile(string fileDir, out string json)
        {
            json = "";

            if (File.Exists(fileDir))
            {
                try
                {
                    json = File.ReadAllText(fileDir);
                }
                catch (Exception)
                {
                    ErrorLogging.LogLine(string.Format("File at '{0}' couldn't be parsed to Json", fileDir));
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
