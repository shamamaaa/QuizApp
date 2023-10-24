using System;
namespace PracticeConsoleApp24._10.Exceptions
{
	public class WrongInputException:Exception
	{
        private const string _message = "Wrong input";

        public WrongInputException(string message = _message) : base(message)
        {
        }
    }
}

