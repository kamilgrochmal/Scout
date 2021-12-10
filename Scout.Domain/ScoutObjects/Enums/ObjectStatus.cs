using System.ComponentModel.DataAnnotations;

namespace Scout.Domain.ScoutObjects.Enums;

public enum ObjectStatus : short
{
    [Display(Name = "Brak danych")]
    NoData = 0,
    [Display(Name = "Nieaktywny")]
    Inactive = 5,
    [Display(Name = "Nieznany")]
    Unknown = 10,
    [Display(Name = "W naprawie")]
    InRepair = 15,
    [Display(Name = "Aktywny")]
    Active = 20
}