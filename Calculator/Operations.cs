namespace Calculator;

interface IOperation 
{ 
    public double Execute(double a, double b);
}

public class Plus : IOperation
{
    public double Execute(double a, double b) => a + b;
}

public class Minus : IOperation
{
    public double Execute(double a, double b) => a - b;
}

public class Multiplication : IOperation
{
    public double Execute(double a, double b) => a * b;
}

public class Division : IOperation
{
    public double Execute(double a, double b) => a / b;
}

class Context(IOperation operation)
{
    private IOperation _operation = operation;
    public IOperation Operation
    {
        set { _operation = value; }
    }
    public double ExecuteOperation(double a, double b) => _operation.Execute(a, b);
}
