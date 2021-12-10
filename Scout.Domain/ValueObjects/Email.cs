using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using Scout.Domain.Exceptions;

namespace Scout.Domain.ValueObjects;

public record Email
{
    public string EmailAddress { get; }

    private Email(string emailAddress)
    {
        EmailAddress = emailAddress;
    }

    public static Email Create(string emailAddress)
    {
        Guard.Against.NullOrWhiteSpace(emailAddress, nameof(emailAddress));

        Regex emailValidation = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        var isValid = emailValidation.IsMatch(emailAddress);

        if (!isValid)
            throw new InvalidEmailAddressException();

        return new Email(emailAddress);
    }
}