using System.Collections.Generic;

namespace TestsWebApp.Models
{
    public class Test
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<Question> Questions { get; set; } = new List<Question>();

        public virtual List<UserTest> UserTests { get; set; } = new List<UserTest>();
    }
}
