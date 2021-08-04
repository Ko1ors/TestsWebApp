using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestsWebApp.Models
{
    public class TestState
    {
        public Test Test { get; set; }

        public int CurrentQuestionIndex { get; set; }

        public int QuestionsCount { get; set; }

        public int CurrentScore { get; set; }
    }
}
