using LiskovSubstitutionGood.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiskovSubstitutionGood
{
    public class SqlFileManager
    {
        private List<IReadableSqlFile> _sqlReadableFiles { get; set; }
        private List<IWritableSqlFile> _sqlWritableFiles { get; set; }

        public SqlFileManager(List<IWritableSqlFile> writableSqlFiles, List<IReadableSqlFile> readableSqlFiles)
        {
            _sqlWritableFiles = writableSqlFiles;
            _sqlReadableFiles = readableSqlFiles;
        }

        public string GetTextFromFiles()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var sqlFile in _sqlReadableFiles)
            {
                sb.Append(sqlFile.LoadText());
            }
            return sb.ToString();
        }

        public void SaveTextIntoFiles()
        {
            foreach (var sqlFile in _sqlWritableFiles)
            {
                sqlFile.SaveText();
            }
        }
    }
}
