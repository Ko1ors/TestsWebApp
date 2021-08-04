using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using TestsWebApp.Models;

namespace TestsWebApp.Data
{
    public static class SeedData
    {
        public static void Seed(ApplicationDbContext context)
        {
                if (context.Tests.Any())
                {
                    return;
                }

                context.Tests.AddRange(
                    new Test
                    {
                        Name = "Test 1",
                        Description = "Test 1 Description",
                        Questions = new List<Question>()
                    {
                        new Question { Name = "Question 1", Description = "Question 1 Description",
                            Answers = new List<Answer>()
                            {
                                new Answer { Description = "Answer 1" },
                                new Answer { Description = "Answer 2" },
                                new Answer { Description = "Answer 3 (Correct)", IsCorrect = true },
                                new Answer { Description = "Answer 4" }
                            }
                        },
                        new Question { Name = "Question 2", Description = "Question 2 Description",
                            Answers = new List<Answer>()
                            {
                                new Answer { Description = "Answer 1" },
                                new Answer { Description = "Answer 2" },
                                new Answer { Description = "Answer 3 (Correct)", IsCorrect = true },
                                new Answer { Description = "Answer 4" }
                            }
                        },
                        new Question { Name = "Question 3", Description = "Question 3 Description",
                            Answers = new List<Answer>()
                            {
                                new Answer { Description = "Answer 1" },
                                new Answer { Description = "Answer 2 (Correct)", IsCorrect = true  },
                                new Answer { Description = "Answer 3" }
                            }
                        }
                    }
                    },
                new Test
                {
                    Name = "Test 2",
                    Description = "Test 2 Description",
                    Questions = new List<Question>()
                    {
                        new Question { Name = "Question 1", Description = "Question 1 Description",
                            Answers = new List<Answer>()
                            {
                                new Answer { Description = "Answer 1" },
                                new Answer { Description = "Answer 2" },
                                new Answer { Description = "Answer 3 (Correct)", IsCorrect = true },
                                new Answer { Description = "Answer 4" }
                            }
                        },
                        new Question { Name = "Question 2", Description = "Question 2 Description",
                            Answers = new List<Answer>()
                            {
                                new Answer { Description = "Answer 1" },
                                new Answer { Description = "Answer 2" },
                                new Answer { Description = "Answer 3 (Correct)", IsCorrect = true },
                                new Answer { Description = "Answer 4" }
                            }
                        },
                        new Question { Name = "Question 3", Description = "Question 3 Description",
                            Answers = new List<Answer>()
                            {
                                new Answer { Description = "Answer 1" },
                                new Answer { Description = "Answer 2 (Correct)", IsCorrect = true  },
                                new Answer { Description = "Answer 3" }
                            }
                        },
                        new Question { Name = "Question 4", Description = "Question 4 Description",
                            Answers = new List<Answer>()
                            {
                                new Answer { Description = "Answer 1" },
                                new Answer { Description = "Answer 2" },
                                new Answer { Description = "Answer 3 (Correct)", IsCorrect = true }
                            }
                        },
                        new Question { Name = "Question 5", Description = "Question 5 Description",
                            Answers = new List<Answer>()
                            {
                                new Answer { Description = "Answer 1 (Correct)", IsCorrect = true  },
                                new Answer { Description = "Answer 2" },
                                new Answer { Description = "Answer 3" }
                            }
                        }
                    }
                },
                new Test
                {
                    Name = "Test 3",
                    Description = "Test 3 Description",
                    Questions = new List<Question>()
                    {
                        new Question { Name = "Question 1", Description = "Question 1 Description",
                            Answers = new List<Answer>()
                            {
                                new Answer { Description = "Answer 1" },
                                new Answer { Description = "Answer 2" },
                                new Answer { Description = "Answer 3 (Correct)", IsCorrect = true },
                                new Answer { Description = "Answer 4" }
                            }
                        },
                        new Question { Name = "Question 2", Description = "Question 2 Description",
                            Answers = new List<Answer>()
                            {
                                new Answer { Description = "Answer 1" },
                                new Answer { Description = "Answer 2" },
                                new Answer { Description = "Answer 3 (Correct)", IsCorrect = true },
                                new Answer { Description = "Answer 4" }
                            }
                        },
                        new Question { Name = "Question 3", Description = "Question 3 Description",
                            Answers = new List<Answer>()
                            {
                                new Answer { Description = "Answer 1" },
                                new Answer { Description = "Answer 2 (Correct)", IsCorrect = true  },
                                new Answer { Description = "Answer 3" }
                            }
                        }
                    }
                },
                new Test
                {
                    Name = "Test 4",
                    Description = "Test 4 Description",
                    Questions = new List<Question>()
                    {
                        new Question { Name = "Question 1", Description = "Question 1 Description",
                            Answers = new List<Answer>()
                            {
                                new Answer { Description = "Answer 1" },
                                new Answer { Description = "Answer 2" },
                                new Answer { Description = "Answer 3 (Correct)", IsCorrect = true },
                                new Answer { Description = "Answer 4" }
                            }
                        },
                        new Question { Name = "Question 2", Description = "Question 2 Description",
                            Answers = new List<Answer>()
                            {
                                new Answer { Description = "Answer 1" },
                                new Answer { Description = "Answer 2" },
                                new Answer { Description = "Answer 3 (Correct)", IsCorrect = true },
                                new Answer { Description = "Answer 4" }
                            }
                        },
                        new Question { Name = "Question 3", Description = "Question 3 Description",
                            Answers = new List<Answer>()
                            {
                                new Answer { Description = "Answer 1" },
                                new Answer { Description = "Answer 2 (Correct)", IsCorrect = true  },
                                new Answer { Description = "Answer 3" }
                            }
                        }
                    }
                });

                context.SaveChanges();
        }
    }
}
