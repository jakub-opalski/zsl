using LiskovSubstitutionBad.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiskovSubstitutionBad
{
    class Processor
    {
        public void Run()
        {
            var list = new List<SqlFile>();
            list.Add(new SqlReadonlyFile());
            list.Add(new SqlFile());

            var manager = new SqlFileManager(list);
            manager.GetTextFromFiles();
            manager.SaveTextIntoFiles();
        }
    }
}
