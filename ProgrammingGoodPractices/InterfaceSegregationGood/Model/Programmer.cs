using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSegregationBad.Models
{
    public class Programmer : ILead, IDevelop
    {
        public void AssignTask()
        {
            
        }

        public void CreateSubTask()
        {
            
        }

        public void WorkOnTask()
        {
            
        }
    }
}
