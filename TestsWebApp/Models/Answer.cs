using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestsWebApp.Models
{
    public class Answer
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public bool IsCorrect { get; set; }

        public virtual Question Question { get; set; }
    }
}
