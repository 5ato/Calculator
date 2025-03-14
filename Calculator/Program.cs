namespace Calculator;

class Program
{
    public static void Main()
    {
        string[] input = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        double i = double.Parse(input[0]);
        string oper = input[1];
        double j = double.Parse(input[2]);

        Dictionary<string, IOperation> dict = new()
        {
            {"+", new Plus()},
            {"-", new Minus()},
            {"*", new Multiplication()},
            {":", new Division()},
        };
        Context context = new(dict[oper]);
        Console.WriteLine(context.ExecuteOperation(i, j));
    }
}