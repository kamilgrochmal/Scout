using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using Scout.Domain.Exceptions;

namespace Scout.Domain.ValueObjects;

public record Address
{
    public string Street { get; }
    public string City { get; }
    public string PostalCode { get; }
    public string PlotNumber { get; }
    public string HouseNumber { get; }

    private Address(string street, string postalCode, string city, string plotNumber, string houseNumber)
    {
        Street = street;
        PostalCode = postalCode;
        City = city;
        PlotNumber = plotNumber;
        HouseNumber = houseNumber;
    }

    public static Address Create(string street, string postalCode, string city, string plotNumber = null,
        string houseNumber = null)
    {
        if (postalCode != null)
        {
            Regex postalCodeValidation = new Regex(@"^\d{2}-\d{3}$");
            var isMatched = postalCodeValidation.IsMatch(postalCode);

            if (!isMatched)
                throw new InvalidPostalCodeException();
        }
        
        if (street != null)
        {
            Guard.Against.NullOrWhiteSpace(street, nameof(street));
        }
        if (city != null)
        {
            Guard.Against.NullOrWhiteSpace(city, nameof(city));
        }

        if (plotNumber != null)
        {
            Guard.Against.NullOrWhiteSpace(plotNumber, nameof(plotNumber));
        }

        if (houseNumber != null)
        {
            Guard.Against.NullOrWhiteSpace(houseNumber, nameof(houseNumber));
        }

        return new Address(street, postalCode, city, plotNumber, houseNumber);
    }
}