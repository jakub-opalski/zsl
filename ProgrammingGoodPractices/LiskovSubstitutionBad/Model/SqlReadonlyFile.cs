using System;
using System.Collections.Generic;
using System.Text;

namespace LiskovSubstitutionBad.Model
{
    public class SqlReadonlyFile : SqlFile
    {
        public override void SaveText()
        {
            throw new Exception();
        }
    }
}
