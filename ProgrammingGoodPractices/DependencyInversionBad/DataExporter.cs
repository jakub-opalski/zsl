using DependencyInversionBad.Loggers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DependencyInversionBad
{
    public class DataExporter
    {
        public DataExporter()
        {

        }

        public void ExportDataFromFile()
        {
            try
            {

            }
            catch (IOException ex)
            {
                new FileLogger().LogMessage(ex.Message);
            }
        }
    }
}
