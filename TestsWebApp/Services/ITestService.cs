using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestsWebApp.Models;

namespace TestsWebApp.Services
{
    public interface ITestService
    {
        Task<bool> HasStartedTest(User user);

        Task<Test> GetStartedTest(User user);

        Task<Question> StartTest(User user, Test test);

        void AddCurrentQuestionAnswer(User user, Answer answer);

        Task<Question> GetCurrentQuestion(User user);

        Task<(int score, int maxScore)> FinishTest(User user);
    }
}
