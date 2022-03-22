using LiskovSubstitutionBad.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LiskovSubstitutionBad
{
    public class SqlFileManager
    {
        private List<SqlFile> _sqlFiles { get; set; }
        
        public SqlFileManager(List<SqlFile> sqlFiles)
        {
            _sqlFiles = sqlFiles;
        }

        public string GetTextFromFiles()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var sqlFile in _sqlFiles)
            {
                sb.Append(sqlFile.LoadText());
            }
            return sb.ToString();
        }

        public void SaveTextIntoFiles()
        {
            foreach (var sqlFile in _sqlFiles)
            {
                sqlFile.SaveText();
            }
        }
    }
}
