using System.ComponentModel.DataAnnotations;

namespace Scout.Domain.LeaseContracts.Enums;

public enum CurrencyType : short
{
    [Display(Name = "Brak danych")]
    NoData = 0,
    USD = 2,
    EUR = 4,
    PLN = 6
}