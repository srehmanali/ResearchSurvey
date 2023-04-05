using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDomain.ViewModels.SurveyModel
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public string ControlType { get; set; }
        public List<Option> Options { get; set; }
        public int SelectedId { get; set; }
        public int[] SelectedIds { get; set; }
        public string AnswerText { get; set; }
        public string ParentQuestion { get; set; }
        public List<SubQuestion> SubQuestions { get; set; }
    }
}