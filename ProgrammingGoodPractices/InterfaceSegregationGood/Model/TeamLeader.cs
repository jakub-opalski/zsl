using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSegregationBad.Models
{
    public class TeamLeader : ILead, IDevelop
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
