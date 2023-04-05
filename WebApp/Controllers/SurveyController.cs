
using CoreDomain.ViewModels.SurveyModel;
using DataService.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ILogger<SurveyController> _logger;
        IEnumerable<CoreDomain.DataModels.Questionnaire.Answer> Answers;
        ApplicationDbContext context;
        private readonly SignInManager<CoreDomain.DataModels.Internal.ApplicationUser> _signInManager; 
        private readonly UserManager<CoreDomain.DataModels.Internal.ApplicationUser> _userManager;


        public SurveyController(ILogger<SurveyController> logger, UserManager<CoreDomain.DataModels.Internal.ApplicationUser> userManager, SignInManager<CoreDomain.DataModels.Internal.ApplicationUser> signInManager, ApplicationDbContext context, IEnumerable<CoreDomain.DataModels.Questionnaire.Answer> Answers)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            this.context = context;
            this.Answers = Answers;
        }

        public IActionResult StartSurvey()
        {
            var result = context.Questions
                   .Join(
                       context.QuestionTypes,
                       question => question.QuestionTypeId,
                       questionType => questionType.Id,
                       (question, questionType) => new { question, questionType })
                   .Where(x => x.question.ParentId == null)
                   .OrderBy(o => o.question.OrderNum)
                   .Select(rec => new Question()
                   {
                       QuestionId = rec.question.Id,
                       QuestionText = rec.question.Text,
                       QuestionType = rec.questionType.TypeName,
                       SubQuestions = context.Questions
                                .Where(q => q.ParentId == rec.question.Id)
                                .Select(s => new SubQuestion()
                                {
                                    QuestionId = s.Id,
                                    QuestionText = s.Text
                                }).ToList(),
                       ControlType = rec.questionType.ControlType,
                       Options = context.Answers.Where(o => o.QuestionId == rec.question.Id)
                                   .OrderBy(o => o.OrderNum)
                                   .Select(opt => new Option
                                   {
                                       OptionId = opt.Id,
                                       OptionText = opt.AnswerText
                                   }).ToList()
                   }).ToList();
            Questionnaire questionnaire = new Questionnaire();
            questionnaire.Questions = result;
            return View(questionnaire);
        }


        [HttpPost]
        public IActionResult PostSurvey(Questionnaire questionnaire)
        {
            CultureInfo culture = new CultureInfo("en-gb");
            string username = "Unknown User";
            string userid = null;
            string location = null;
            string assignedLocation = null;
            string assignedLocationLatLong = null;
            if (_signInManager.IsSignedIn(User))
            {
                var identity = (ClaimsIdentity)User.Identity;
                username = _userManager.GetUserAsync(User).Result.FirstName + " " + _userManager.GetUserAsync(User).Result.LastName;
                userid = _userManager.GetUserId(HttpContext.User);
                assignedLocation = _userManager.GetUserAsync(User).Result.AssignedLocation;
                assignedLocationLatLong = _userManager.GetUserAsync(User).Result.AssignedLocationLatLong;
                location = questionnaire.LatLong;
            }
            if (ModelState.IsValid)
            {
                Answers = context.Answers.ToList();

                CoreDomain.DataModels.Questionnaire.Response res = new CoreDomain.DataModels.Questionnaire.Response();

                res.UserId = userid;
                res.Username = username;
                res.LatLong = location;
                //res.StartTime = DateTime.ParseExact(questionnaire.StartTime, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);  
                res.StartTime = Convert.ToDateTime(questionnaire.StartTime, culture);
                //res.EndTime = DateTime.ParseExact(questionnaire.EndTime, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture); 
                res.EndTime = Convert.ToDateTime(questionnaire.EndTime, culture);
                res.CreateDate = DateTime.UtcNow;
                res.SurveyStatus = questionnaire.SurveyStatus;
                res.AssignedLocation = assignedLocation;
                res.AssignedLocationLatLong = assignedLocationLatLong;

                res.O1 = GetOptionValue(questionnaire, 2);

                res.Q1 = GetOptionValue(questionnaire, 4);
                res.Q2 = GetOptionValue(questionnaire, 5);
                res.Q3 = GetOptionValue(questionnaire, 6);
                res.Q4 = GetOptionValue(questionnaire, 7);
                res.Q5 = GetOptionValue(questionnaire, 8);

                res.Q6 = GetOptionValue(questionnaire.Questions.Where(x => x.QuestionId == 10).Select(x => x.SubQuestions).First().Where(x => x.QuestionId == 11).Select(x => x.SelectedId).First());
                res.Q7 = GetOptionValue(questionnaire.Questions.Where(x => x.QuestionId == 10).Select(x => x.SubQuestions).First().Where(x => x.QuestionId == 12).Select(x => x.SelectedId).First());
                res.Q8 = GetOptionValue(questionnaire.Questions.Where(x => x.QuestionId == 10).Select(x => x.SubQuestions).First().Where(x => x.QuestionId == 13).Select(x => x.SelectedId).First());
                res.Q9 = GetOptionValue(questionnaire.Questions.Where(x => x.QuestionId == 10).Select(x => x.SubQuestions).First().Where(x => x.QuestionId == 14).Select(x => x.SelectedId).First());
                res.Q10 = GetOptionValue(questionnaire.Questions.Where(x => x.QuestionId == 10).Select(x => x.SubQuestions).First().Where(x => x.QuestionId == 15).Select(x => x.SelectedId).First());
                res.Q11 = GetOptionValue(questionnaire.Questions.Where(x => x.QuestionId == 10).Select(x => x.SubQuestions).First().Where(x => x.QuestionId == 16).Select(x => x.SelectedId).First());

                res.Q12 = GetOptionValue(questionnaire.Questions.Where(x => x.QuestionId == 17).Select(x => x.SubQuestions).First().Where(x => x.QuestionId == 18).Select(x => x.SelectedId).First());
                res.Q13 = GetOptionValue(questionnaire.Questions.Where(x => x.QuestionId == 17).Select(x => x.SubQuestions).First().Where(x => x.QuestionId == 19).Select(x => x.SelectedId).First());
                res.Q14 = GetOptionValue(questionnaire.Questions.Where(x => x.QuestionId == 17).Select(x => x.SubQuestions).First().Where(x => x.QuestionId == 20).Select(x => x.SelectedId).First());
                res.Q15 = GetOptionValue(questionnaire.Questions.Where(x => x.QuestionId == 17).Select(x => x.SubQuestions).First().Where(x => x.QuestionId == 21).Select(x => x.SelectedId).First());
                res.Q16 = GetOptionValue(questionnaire.Questions.Where(x => x.QuestionId == 17).Select(x => x.SubQuestions).First().Where(x => x.QuestionId == 22).Select(x => x.SelectedId).First());
                res.Q17 = GetOptionValue(questionnaire.Questions.Where(x => x.QuestionId == 17).Select(x => x.SubQuestions).First().Where(x => x.QuestionId == 23).Select(x => x.SelectedId).First());

                res.Q18 = GetOptionValue(questionnaire.Questions.Where(x => x.QuestionId == 24).Select(x => x.SubQuestions).First().Where(x => x.QuestionId == 25).Select(x => x.SelectedId).First());
                res.Q19 = GetOptionValue(questionnaire.Questions.Where(x => x.QuestionId == 24).Select(x => x.SubQuestions).First().Where(x => x.QuestionId == 26).Select(x => x.SelectedId).First());
                res.Q20 = GetOptionValue(questionnaire.Questions.Where(x => x.QuestionId == 24).Select(x => x.SubQuestions).First().Where(x => x.QuestionId == 27).Select(x => x.SelectedId).First());
                res.Q21 = GetOptionValue(questionnaire.Questions.Where(x => x.QuestionId == 24).Select(x => x.SubQuestions).First().Where(x => x.QuestionId == 28).Select(x => x.SelectedId).First());

                res.Q22 = GetOptionValue(questionnaire.Questions.Where(x => x.QuestionId == 29).Select(x => x.SubQuestions).First().Where(x => x.QuestionId == 30).Select(x => x.SelectedId).First());
                res.Q23 = GetOptionValue(questionnaire.Questions.Where(x => x.QuestionId == 29).Select(x => x.SubQuestions).First().Where(x => x.QuestionId == 31).Select(x => x.SelectedId).First());
                res.Q24 = GetOptionValue(questionnaire.Questions.Where(x => x.QuestionId == 29).Select(x => x.SubQuestions).First().Where(x => x.QuestionId == 32).Select(x => x.SelectedId).First());
               


                context.Responses.Add(res);
                context.SaveChanges();
            }
            return RedirectToAction("SurveyComplete");
        }

        public IActionResult SurveyComplete()
        {
            return View();
        }


        private string GetOptionValue(Questionnaire questionnaire, int questionId)
        {
            int selectedId = questionnaire.Questions.Where(x => x.QuestionId == questionId).Select(s => s.SelectedId).First();
            return Answers.Where(o => o.Id == selectedId).Select(x => x.AnswerText).FirstOrDefault();
        }
        private string GetOptionValue(int questionId)
        {
            return Answers.Where(o => o.Id == questionId).Select(x => x.AnswerText).FirstOrDefault();
        }

    }
}
