using System.ComponentModel.DataAnnotations;

namespace Scout.Domain.ScoutObjects.Enums;

public enum PowerSupplyType : short
{
    [Display(Name = "Brak danych")]
    NoData = 0,
    [Display(Name = "Stałe")]
    Permanent = 2,
    [Display(Name = "1 linia zasilająca")]
    OnePowerLine = 4,
    [Display(Name = "2 linie zasilające")]
    TwoPowerLine = 6
    
    
}