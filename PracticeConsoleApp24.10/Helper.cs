using System;
using System.Text;

namespace PracticeConsoleApp24._10
{
	public static class Helper
	{
		public static string Capitalize(this string input)
		{
            string[] newstr = input.Split(' ');
            StringBuilder sb = new StringBuilder();
            foreach (string item in newstr)
            {

                if (item.Length != 0)
                {
                    sb.Append(item.Substring(0, 1).ToUpper());
                    sb.Append(item.Substring(1).ToLower());
                    sb.Append(" ");
                }
            }

            return sb.ToString();
        }
	}
}

