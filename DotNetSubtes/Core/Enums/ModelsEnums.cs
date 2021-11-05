using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
    public class ModelsEnums
    {
    }

    public enum Cause
    {
        [Display(Name = "Unknown")]
        unknown_cause = 1,
        [Display(Name = "Others")]
        other_cause = 2,
        [Display(Name = "Technical Problems")]
        technical_problem = 3,
        strike = 4,
        [Display(Name = "Demostration")]
        demonstration = 5,
        [Display(Name = "Accident")]
        accident = 6,
        [Display(Name = "Holidays")]
        holiday = 7,
        [Display(Name = "Weather")]
        weather = 8,
        [Display(Name = "Maintenance")]
        maintenance = 9,
        [Display(Name = "Construction")]
        construction = 10,
        [Display(Name = "Police activity")]
        police_activity = 11,
        [Display(Name = "Medical Emergency")]
        medical_emergency = 12
    }

    public enum Effect
    {
        [Display(Name = "No service")]
        no_service = 1,
        [Display(Name = "Reduced service")]
        reduced_service = 2,
        [Display(Name = "Delays")]
        significant_delays = 3, 
        [Display(Name = "Detour")]
        detour = 4,
        [Display(Name = "Additional service")]
        additional_service = 5,
        [Display(Name = "Modified service")]
        modified_service = 6,
        [Display(Name = "Others")]
        other_effect = 7,
        [Display(Name = "Unknown")]
        unknown_effect = 8,
        [Display(Name = "Stop moved")]
        stop_moved = 9
    }
}
