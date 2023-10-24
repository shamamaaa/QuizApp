using System;
using PracticeConsoleApp24._10.Exceptions;

namespace PracticeConsoleApp24._10.Models
{
	public class Quiz
	{
        private static int Count = 0;
        public string Name { get; set; }
		public int ID { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();

        public Quiz(string name, List<Question> questions)
		{
            Count++;
            ID = Count;
			Name = name;
            Questions = questions;

        }

        public static void CreateQuiz(List<Quiz> quizzes)
        {
                Console.Write("Enter quiz name:");
                string name = Console.ReadLine().Capitalize();
                name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
                if (name.Length >= 3 && name.Length < 25)
                {
                    restartaddquestion:
                    Console.Write("How many questions do you want to add?");
                    if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 1) //test en az 2 sual olmalidi
                    {
                        List<Question> questions = new List<Question>();
                        for (int i = 0; i < quantity; i++)
                        {
                            questions.Add(Question.CreateQuestion());
                        }

                        Quiz quiz = new Quiz(name, questions);
                        quizzes.Add(quiz);
                    }
                    else
                    {
                        Console.WriteLine("Wrong input. Enter correct number.(Quiz must be at least 2 questions)");
                        goto restartaddquestion;
                    }
                }
                else
                {
                    throw new WrongInputException();
                }

            
        }

        public static void SolveAQuiz(Quiz quiz)
        {
            int score = 0;
            Console.WriteLine(quiz.Name);

            foreach (Question question in quiz.Questions)
            {
                Console.WriteLine("------------------");
                Console.WriteLine(question.Text);
                Console.WriteLine("------------------");

                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine($"{i+1}){question.Variants[i]}");
                }

                Console.Write("\nYour answer:");

                    restartanswer:
                    bool answer = false;
                    if (int.TryParse(Console.ReadLine(), out int id) && id>0 && id<5)
                    {
                        if (id == question.CorrectId)
                        {
                            score++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input");
                        goto restartanswer;
                    }

            }
            Console.WriteLine($"Your score: {score}/{quiz.Questions.Count}");
        }

    }
}

