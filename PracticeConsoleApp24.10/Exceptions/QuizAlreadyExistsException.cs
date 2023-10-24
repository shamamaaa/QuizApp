using System;
namespace PracticeConsoleApp24._10.Exceptions
{
	public class QuizAlreadyExistsException:Exception
	{
        private const string _message = "Quiz already exsist";

        public QuizAlreadyExistsException(string message = _message) : base(message)
        {
        }
    }
}

