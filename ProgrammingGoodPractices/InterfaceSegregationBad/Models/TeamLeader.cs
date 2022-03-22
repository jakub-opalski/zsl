using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSegregationBad.Models
{
    public class TeamLeader : IDeveloper
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
