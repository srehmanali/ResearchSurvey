using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDomain.ViewModels.SurveyModel
{
    public class Questionnaire
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string LatLong { get; set; }
        public string SurveyStatus { get; set; }
        public List<Question> Questions { get; set; }
    }
}
