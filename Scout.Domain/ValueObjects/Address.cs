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

    private Address(string street, string postalCode, string city, string plotNumber)
    {
        Street = street;
        PostalCode = postalCode;
        City = city;
        PlotNumber = plotNumber;
    }

    public static Address Create(string street, string postalCode, string city, string plotNumber = null)
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

     

        return new Address(street, postalCode, city, plotNumber);
    }
}