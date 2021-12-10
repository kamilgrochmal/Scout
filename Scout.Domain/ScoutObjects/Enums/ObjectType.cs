using System.ComponentModel.DataAnnotations;

namespace Scout.Domain.ScoutObjects.Enums;

public enum ObjectType : short
{
    [Display(Name = "Brak danych")]
    NoData = 0,
    [Display(Name = "Komin")]
    Chimney = 2,
    [Display(Name = "Wieża")]
    Tower = 4,
    [Display(Name = "Inne")]
    Other = 8
    
}