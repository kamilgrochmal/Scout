using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using Scout.Domain.Exceptions;

namespace Scout.Domain.ValueObjects;

public class PhoneNumber
{
     public string Number { get; }

     private PhoneNumber(string number)
     {
          Number = number;
     }

     public static PhoneNumber Create(string number)
     {
          Guard.Against.NullOrWhiteSpace(number, nameof(number));

          Regex phoneNumberValidation = new Regex("\\d{9}");
          var isValid = phoneNumberValidation.IsMatch(number);

          if (!isValid)
               throw new InvalidPhoneNumberException();

          return new PhoneNumber(number);

     }
     
}