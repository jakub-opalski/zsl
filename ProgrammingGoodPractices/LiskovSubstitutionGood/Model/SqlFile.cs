using System;
using System.Collections.Generic;
using System.Text;

namespace LiskovSubstitutionGood.Model
{
    public class SqlFile : IReadableSqlFile, IWritableSqlFile
    {
        public string FilePath { get; set; }
        public string FileText { get; set; }

        public virtual string LoadText()
        {
            //read text
            return "";
        }

        public virtual void SaveText()
        {
            //save text
        }
    }
}
