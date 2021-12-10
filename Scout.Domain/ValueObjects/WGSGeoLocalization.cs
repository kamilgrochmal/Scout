using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using Scout.Domain.Exceptions;

namespace Scout.Domain.ValueObjects;

public record WGSGeoLocalization
{
    public double? Latitude { get; }
    public double? Longitude { get; }
    public double? TerrainHeight { get; }

    private WGSGeoLocalization(double? latitude, double? longitude, double? terrainHeight)
    {
        Latitude = latitude;
        Longitude = longitude;
        TerrainHeight = terrainHeight;
    }

    public static WGSGeoLocalization Create(double? latitude, double? longitude, double? terrainHeight)
    {
        if (latitude != null && longitude != null)
        {
            Regex regexObj = new Regex(@"^([-+]?)([\d]{1,2})(((\.)(\d+)(,)))(\s*)(([-+]?)([\d]{1,3})((\.)(\d+))?)$");
            var matchResult = regexObj.IsMatch($"{latitude}, {longitude}");

            if (!matchResult)
                throw new InvalidCoordinatesException();
        }
        
        if (terrainHeight != null)
        {
            Guard.Against.NegativeOrZero((double)terrainHeight, nameof(terrainHeight));
        }

        return new WGSGeoLocalization(latitude, longitude, terrainHeight);
    }
}