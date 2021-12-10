using System.ComponentModel.DataAnnotations;

namespace Scout.Domain.ScoutObjects.Enums;

public enum CoolingType : short
{
    [Display(Name = "Brak danych")]
    NoData = 0,
    [Display(Name = "Klimatyzacja")]
    AirConditioning = 2,
    [Display(Name = "Wentylacja")]
    Ventilation = 4,
    [Display(Name = "Freecooling")]
    FreeCooling = 6
    
    
}