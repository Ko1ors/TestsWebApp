using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestsWebApp.Models
{
    public class UserTest
    {
        public int ID { get; set; }

        public int Score { get; set; }

        public bool IsCompleted { get; set; }

        [Required]
        public virtual Test Test { get; set; }

        [Required]
        public virtual User User { get; set; }

    }
}
