// CalculatorModel.cs
public class CalculatorModel
{
    public double Number1 { get; set; }
    public double Number2 { get; set; }

    public double Calculate(string operation)
    {
        if (operation == null)
        {
            throw new ArgumentNullException(nameof(operation));
        }

        switch (operation)
        {
            case "Addition":
                return Number1 + Number2;
            case "Subtraction":
                return Number1 - Number2;
            case "Multiplication":
                return Number1 * Number2;
            case "Division":
                return Number1 / Number2;
            default:
                throw new ArgumentException("Invalid operation");
        }
    }
}
