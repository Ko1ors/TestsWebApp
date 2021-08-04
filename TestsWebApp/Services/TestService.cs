using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestsWebApp.Models;

namespace TestsWebApp.Services
{
    public class TestService : ITestService
    {
        private Dictionary<string, TestState> StartedTestDict { get; set; } = new Dictionary<string, TestState>();

        public async Task<Test> GetStartedTest(User user)
        {
            Test test = null;
            if (await HasStartedTest(user))
                test = StartedTestDict.GetValueOrDefault(user.Id)?.Test;
            return test;
        }

        public Task<bool> HasStartedTest(User user)
        {
            return Task.FromResult(StartedTestDict.ContainsKey(user.Id));
        }

        public async Task<Question> StartTest(User user, Test test)
        {
            Question question = null;
            if (!await HasStartedTest(user))
            {
                StartedTestDict.Add(user.Id, new TestState { Test = test, CurrentScore = 0, CurrentQuestionIndex = 0, QuestionsCount = test.Questions.Count });
                question = test.Questions[0];
            }
            return question;
        }

        public async void AddCurrentQuestionAnswer(User user, Answer answer)
        {
            if (await HasStartedTest(user))
            {
                var testState = StartedTestDict.GetValueOrDefault(user.Id);
                if (answer.IsCorrect)
                    testState.CurrentScore++;
                testState.CurrentQuestionIndex++;
            }
        }

        public async Task<Question> GetCurrentQuestion(User user)
        {
            Question question = null;
            if (await HasStartedTest(user))
            {
                var testState = StartedTestDict.GetValueOrDefault(user.Id);
                if (testState.Test.Questions.ElementAtOrDefault(testState.CurrentQuestionIndex) != null)
                    question = testState.Test.Questions[testState.CurrentQuestionIndex];
            }
            return question;
        }

        public async Task<(int score, int maxScore)> FinishTest(User user)
        {
            if (await HasStartedTest(user))
            {
                var testState = StartedTestDict.GetValueOrDefault(user.Id);
                StartedTestDict.Remove(user.Id);
                if (testState.QuestionsCount > 0)
                    return (testState.CurrentScore, testState.QuestionsCount);
            }
            return (0, 0);
        }
    }
}
