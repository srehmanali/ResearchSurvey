using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDomain.DataModels.Questionnaire
{
    public class QuestionType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }

        public string ControlType { get; set; }
        public ICollection<Question> Qustion { get; set; }
    }
}
