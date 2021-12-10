using System.ComponentModel.DataAnnotations;

namespace Scout.Domain.ContactPersons.Enums;

public enum DepartmentType : short
{
    [Display(Name = "Brak danych")]
    NoData = 0,
    [Display(Name = "Dział techniczny")]
    Technical = 2,
    [Display(Name = "Dział księgowy")]
    Accounting = 4,
    [Display(Name = "Dział administracji")]
    Administration = 6
    
}