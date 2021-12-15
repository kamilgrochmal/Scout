using Ardalis.GuardClauses;
using Scout.Domain.ScoutObjects.Enums;

namespace Scout.Domain.ValueObjects;

public record ObjectSpecification
{
    public double? ObjectHeight { get; }
    public PowerSupplyType? PowerSupplyType { get; }
    public CoolingType? CoolingType { get; }
    public double? AntennaSetHeight { get; }
    public string Others { get; }

    private ObjectSpecification(double? antennaSetHeight, CoolingType? coolingType, PowerSupplyType? powerSupplyType, double? objectHeight,
        string others)
    {
        Others = others;
        AntennaSetHeight = antennaSetHeight;
     
        CoolingType = coolingType;
        PowerSupplyType = powerSupplyType;
        ObjectHeight = objectHeight;
    }

    public static ObjectSpecification Create(double? antennaSetHeight,CoolingType? coolingType, PowerSupplyType? powerSupplyType, double? objectHeight,
        string others)
    {
        if (antennaSetHeight != null)
        {
            Guard.Against.NegativeOrZero((double)antennaSetHeight, nameof(antennaSetHeight));
        }
        
        if (objectHeight != null)
        {
            Guard.Against.NegativeOrZero((double)objectHeight, nameof(objectHeight));
        }

        return new ObjectSpecification(antennaSetHeight, coolingType, powerSupplyType, objectHeight, others);
    }
}