using System.Text;

namespace Calculator;

class AlgorithmCalculate
{
    public static string Solution(string input)
    {
        Dictionary<string, IOperation> dict = new()
        {
            {"+", new Plus()},
            {"-", new Minus()},
            {"*", new Multiplication()},
            {"/", new Division()},
        };
        List<string> list = ParseInput(input);
        string[] operations = ["*", "/", "+", "-"];

        foreach (string operation in operations)
        {
            while (list.Contains(operation))
            {
                int index = list.IndexOf(operation);

                Context work = new(dict[list[index]]);
                double result = work.ExecuteOperation(double.Parse(list[index - 1]), double.Parse(list[index + 1]));
                list.RemoveRange(index - 1, 2);
                list[index - 1] = result.ToString();
            }
        }
        return list[0];
    }

    private static List<string> ParseInput(string input)
    {
        List<string> result = [];
        StringBuilder temp = new();
        foreach (char ch in input)
        {
            if (char.IsWhiteSpace(ch))
            {
                if (temp.Length > 0) result.Add(temp.ToString());
                temp.Clear();
            }
            else if (char.IsDigit(ch))
            {
                temp.Append(ch);
            }
            else
            {
                if (temp.Length > 0) result.Add(temp.ToString());
                result.Add(ch.ToString());
                temp.Clear();
            }
        }
        if (temp.Length > 0) result.Add(temp.ToString());
        return result;
    }
}
