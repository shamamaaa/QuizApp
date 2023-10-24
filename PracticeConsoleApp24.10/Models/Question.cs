using System;
using PracticeConsoleApp24._10.Exceptions;
using static System.Net.Mime.MediaTypeNames;

namespace PracticeConsoleApp24._10.Models
{
	public class Question
	{
        private static int Count = 0;
        public int ID { get; set; }
        public List<string> Variants { get; set; } = new List<string>();
        public string Text { get; set; }
        public int CorrectId { get; set; }


        public Question(string text, List<string>variants, int correctid)
        {
            Count++;
            ID = Count;
            Text = text;
            Variants = variants;
            CorrectId = correctid;
        }

        public static Question CreateQuestion()
        {
            while (true)
            {
                Console.Write("Enter question: ");
                string text = Console.ReadLine().Capitalize();

                if (text.Length>0)
                {
                    List<string> variants = new List<string>();
                    for (int i = 1; i <= 4; i++)
                    {
                        Console.WriteLine($"Enter variant{i}");
                        string variant = Console.ReadLine().Capitalize();
                        if (variant.Length > 0)
                        {
                            variants.Add(variant);
                        }
                        else
                        {
                            throw new WrongInputException();
                        }
                    }

                    Console.Write("\nEnter correct variant number:");

                    if (int.TryParse(Console.ReadLine(), out int CorrectId) && CorrectId < 5 && CorrectId > 0)
                    {
                        Question question = new Question(text, variants, CorrectId);
                        return question;
                    }
                    else
                    {
                        throw new WrongInputException();
                    }
                }
                else
                {
                    throw new WrongInputException();
                }

            }

        }

    }
}

