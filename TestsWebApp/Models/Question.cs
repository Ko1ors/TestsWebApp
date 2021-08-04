using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestsWebApp.Models
{
    public class Question
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<Answer> Answers { get; set; } = new List<Answer>();

        public virtual Test Test { get; set; }
    }
}
