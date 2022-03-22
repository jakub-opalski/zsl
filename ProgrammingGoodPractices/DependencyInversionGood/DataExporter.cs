using DependencyInversionGood.Helpers;
using DependencyInversionGood.Loggers;
using System;
using System.Data.SqlClient;
using System.IO;

namespace DependencyInversionGood
{
    public class DataExporter
    {
        public void ExportDataFromFile()
        {
            try
            {
                //export data
            }
            catch (IOException ex)
            {
                new ExceptionLogger(new DbLogger()).LogException(ex);
            }
            catch (SqlException ex)
            {
                new ExceptionLogger(new EventLogger()).LogException(ex);
            }
            catch (Exception ex)
            {
                new ExceptionLogger(new FileLogger()).LogException(ex);
            }
        }
    }
}
