using ASP.NETFinalExamsProject.Models;

public class CallCostCalculator
{
    public double CalculateCallCost(int duration, string callType)
    {
        double costPerMinute;
        switch (callType)
        {
            case "CellPhone":
                costPerMinute = 0.10;
                break;
            case "FixedLine":
                costPerMinute = 0.08;
                break;
            case "International":
                costPerMinute = 2.0;
                break;
            default:
                throw new ArgumentException("Invalid call type");
        }

        int roundedDuration = (duration + 29) / 60;
        return roundedDuration * costPerMinute;
    }

}