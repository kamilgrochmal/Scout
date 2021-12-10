using System.ComponentModel.DataAnnotations;

namespace Scout.Domain.LeaseContracts.Enums;

public enum ContractType : short
{
    [Display(Name = "Brak danych")]
    NoData = 0,
    [Display(Name = "Na czas określony")]
    FixTerm = 2,
    [Display(Name = "Na czas nieokreślony")]
    IndefinitePeriod  = 4,
    [Display(Name = "Po 36 miesiącach na czas nieokreślony")]
    IndefinitePeriod36 = 6,
    [Display(Name = "Po 40 miesiącach na czas nieokreślony")]
    IndefinitePeriod40 = 8
    
    
}