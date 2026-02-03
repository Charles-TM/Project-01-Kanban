using Kanaban501app.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanaban501app
{
    /// <summary>
    /// Main data strcuture to hold the Goaldialogue entries before and after reading from txt doc
    /// </summary>
    public class GoalActivity
    {
        /// <summary>
        /// goal title
        /// </summary>
        public string Title { get; set; } 
        /// <summary>
        /// date to complete by
        /// </summary>
        public DateTime CompleteBy { get; set; }
        /// <summary>
        /// status for which list box
        /// </summary>
        public Status Status { get; set; } = Status.ToDo;
        /// <summary>
        /// resources from complex text 
        /// </summary>
        public string Resources { get; set; }
        /// <summary>
        /// if the task is overdue
        /// </summary>

        public bool IsOverdue => Status != Status.Done && CompleteBy.Date < DateTime.Today;
        /// <summary>
        /// easier to string for printing goals to mainforms list boxes
        /// </summary>
        /// <returns>formatted string</returns>

        public override string ToString()
        {
            return $"{Title} (Complete By: {CompleteBy:MM/dd/yyyy})";
        }
        /// <summary>
        /// easier internal data to print into the txt document
        /// </summary>
        /// <returns>formatted string data using | as delim</returns>

        public string ToFileString()
        {
            return $"{Title}|{CompleteBy:MM/dd/yyyy}|{Status}|{Resources}";
        }
        /// <summary>
        /// reads ToFileStrings output as input from txt, automatically creating a data structure from the file
        /// </summary>
        /// <param name="line">that individual line, from 0 until EOF</param>
        /// <returns>GoalActivity of that txtline</returns>
        public static GoalActivity FromFileString(string line)
        {
            var parts = line.Split('|');
            return new GoalActivity
            {
                Title = parts[0],
                CompleteBy = DateTime.Parse(parts[1]),
                Status = (Status)Enum.Parse(typeof(Status), parts[2]),
                Resources = parts.Length > 3 ? parts[3] : string.Empty // optional in nature
            };
        }
    }
}
