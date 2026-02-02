using Kanaban501app.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanaban501app
{
    public enum Status
    {
        ToDo,
        WorkingOn,
        Done
    }

    public class GoalActivity
    {
        public string Title { get; set; }
        public DateTime CompleteBy { get; set; }
        public Status Status { get; set; }
        public string Resources { get; set; }

        public bool IsOverdue => Status != Status.Done && CompleteBy.Date < DateTime.Today;

        public override string ToString()
        {
            return $"{Title} (Complete By: {CompleteBy:MM/dd/yyyy})";
        }

        public string ToFileString()
        {
            return $"{Title}|{CompleteBy:MM/dd/yyyy}|{Status}|{Resources}";
        }

        public static GoalActivity FromFileString(string line)
        {
            var parts = line.Split('|');
            return new GoalActivity
            {
                Title = parts[0],
                CompleteBy = DateTime.Parse(parts[1]),
                Status = (Status)Enum.Parse(typeof(Status), parts[2]),
                Resources = parts[3]
            };
        }
    }
}
