using Ardalis.GuardClauses;
using Scout.Domain.ScoutObjects.Enums;

namespace Scout.Domain.ValueObjects;

public record ObjectSpecification
{
    public double ObjectHeight { get; }
    public PowerSupplyType? PowerSupplyType { get; }
    public CoolingType? CoolingType { get; }
    public double? FirstAntennaSetHeight { get; }
    public double? SecondAntennaSetHeight { get; }
    public double? ThirdAntennaSetHeight { get; }
    public string Others { get; }

    private ObjectSpecification(double? firstAntennaSetHeight, double? secondAntennaSetHeight,
        double? thirdAntennaSetHeight, CoolingType? coolingType, PowerSupplyType? powerSupplyType, double objectHeight,
        string others)
    {
        Others = others;
        ThirdAntennaSetHeight = thirdAntennaSetHeight;
        SecondAntennaSetHeight = secondAntennaSetHeight;
        FirstAntennaSetHeight = firstAntennaSetHeight;
        CoolingType = coolingType;
        PowerSupplyType = powerSupplyType;
        ObjectHeight = objectHeight;
    }

    public static ObjectSpecification Create(double? firstAntennaSetHeight, double? secondAntennaSetHeight,
        double? thirdAntennaSetHeight, CoolingType? coolingType, PowerSupplyType? powerSupplyType, double objectHeight,
        string others)
    {
        if (firstAntennaSetHeight != null)
        {
            Guard.Against.NegativeOrZero((double)firstAntennaSetHeight, nameof(firstAntennaSetHeight));
        }

        if (secondAntennaSetHeight != null)
        {
            Guard.Against.NegativeOrZero((double)secondAntennaSetHeight, nameof(secondAntennaSetHeight));
        }

        if (thirdAntennaSetHeight != null)
        {
            Guard.Against.NegativeOrZero((double)thirdAntennaSetHeight, nameof(thirdAntennaSetHeight));
        }

        // if (objectHeight != null)
        // {
        //     Guard.Against.NegativeOrZero((double)objectHeight, nameof(objectHeight));
        // }

        return new ObjectSpecification(firstAntennaSetHeight, secondAntennaSetHeight, thirdAntennaSetHeight,
            coolingType, powerSupplyType, objectHeight, others);
    }
}