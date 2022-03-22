using System;
using System.Collections.Generic;
using System.Text;

namespace LiskovSubstitutionGood.Model
{
    public interface IWritableSqlFile
    {
        void SaveText();
    }
}
