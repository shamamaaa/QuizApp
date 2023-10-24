using System;
namespace PracticeConsoleApp24._10.Exceptions
{
	public class QuizNotFoundException:Exception
	{
        private const string _message = "Quiz not found";

        public QuizNotFoundException(string message = _message) : base(message)
        {
        }
    }
}

