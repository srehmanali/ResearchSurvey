using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDomain.ViewModels.SurveyModel
{
    public class Option
    {
        public int OptionId { get; set; }
        public string OptionText { get; set; }
        public bool IsSelected { get; set; }
    }
}
 