using System;
using System.Collections.Generic;
using System.Text;

namespace LiskovSubstitutionBad.Model
{
    public class SqlFile
    {
        public string FilePath { get; set; }
        public string FileText { get; set; }

        public string LoadText()
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
