using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDomain.ViewModels.SurveyModel
{
    public class QuestionAnswer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int SingleAnswerId { get; set; }
        public int[] MultiAnswerId { get; set; }
        public string Answer { get; set; }
    }
}
