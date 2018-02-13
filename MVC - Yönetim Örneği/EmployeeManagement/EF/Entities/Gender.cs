using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EmployeeManagement.EF.Entities
{
    public enum Gender
    {
        [Display(Name="Kadın")]
        Female,
        [Display(Name="Erkek")]
        Male
    }
}
