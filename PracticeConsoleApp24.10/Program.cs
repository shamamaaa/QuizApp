using PracticeConsoleApp24._10.Exceptions;
using PracticeConsoleApp24._10.Models;

namespace PracticeConsoleApp24._10;
class Program
{
    static void Main(string[] args)
    {
        List<Quiz> quizzes = new List<Quiz>();

        restartMenu:
        Console.WriteLine("[1] Create new quiz");
        Console.WriteLine("[2] Solve a quiz");
        Console.WriteLine("[3] Show quizzes");
        Console.WriteLine("[0] Quit");
        Console.Write(">>>");

        string choice = Console.ReadLine();

        try
        {
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Quiz.CreateQuiz(quizzes);
                    break;
                case "2":
                    Console.Clear();
                    Quiz.SolveAQuiz(SelectQuiz(quizzes));
                    break;
                case "3":
                    Console.Clear();
                    ShowQuizzes(quizzes);
                    break;
                case "0":
                    return;
                default: throw new WrongInputException();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        goto restartMenu;
    }


    //===============================Methodlar===============================



    public static void ShowQuizzes(List<Quiz> quizzes)
    {
        if (quizzes != null && quizzes.Count > 0)
        {
            foreach (Quiz quiz in quizzes)
            {
                Console.WriteLine($"{quiz.ID} || {quiz.Name}");
            }
        }
        else
        {
            Console.WriteLine("First you need to create a quiz");
        }
    }

    public static Quiz SelectQuiz(List<Quiz> quizes)
    {
        restartselectquiz:
            Console.WriteLine("Enter quiz:");
            ShowQuizzes(quizes);

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                foreach (var quiz in quizes)
                {
                    if (quiz.ID == id)
                    {
                        return quiz;
                    }
                    else
                    {
                        throw new QuizNotFoundException();
                    }
                }
            }
            else
            {
                throw new WrongInputException();
            }
        goto restartselectquiz;
    }

}


