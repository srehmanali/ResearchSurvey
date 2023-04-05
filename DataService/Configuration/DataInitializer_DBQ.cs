using CoreDomain.Constants;
using CoreDomain.DataModels.Internal;
using CoreDomain.DataModels.Questionnaire;
using DataService.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Configuration
{
    public static class DataInitializer_DBQ
    {
        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager, context);
            SeedQuestions(context);
            context.SaveChanges();
        }
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync(Roles.Interviewer.ToString()).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = Roles.Interviewer.ToString();
                //role.Description = "Users who will conduct interview.";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync(Roles.AnonymousUser.ToString()).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = Roles.AnonymousUser.ToString();
                //role.Description = "Users Who will fill the survey directly.";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync(Roles.Administrator.ToString()).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = Roles.Administrator.ToString();
                //role.Description = "Perform all the operations.";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }
       
        public static void SeedUsers(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {

            Dictionary<ApplicationUser, string> users = new Dictionary<ApplicationUser, string>()
            {
{ new ApplicationUser { FirstName =DefaultUser.default_firstname, LastName = DefaultUser.default_lastname, UserName =DefaultUser.default_username, Email =DefaultUser.default_email, EmailConfirmed = true, PhoneNumberConfirmed = true},DefaultUser.default_password},
{ new ApplicationUser { FirstName = "KH1", LastName = "User", UserName ="KH1@dbq.keo.com", Email ="KH1@dbq.keo.com", AssignedLocation ="ALL", AssignedLocationLatLong="", EmailConfirmed = true, PhoneNumberConfirmed = true},"KH1@123"},
{ new ApplicationUser { FirstName = "MZ1", LastName = "User", UserName ="MZ1@dbq.keo.com", Email ="MZ1@dbq.keo.com", AssignedLocation ="MZ1", AssignedLocationLatLong="", EmailConfirmed = true, PhoneNumberConfirmed = true},"MZ1@123"},
{ new ApplicationUser { FirstName = "AA1", LastName = "User", UserName ="AA1@dbq.keo.com", Email ="AA1@dbq.keo.com", AssignedLocation ="AA1", AssignedLocationLatLong="", EmailConfirmed = true, PhoneNumberConfirmed = true},"AA1@123"},
{ new ApplicationUser { FirstName = "YS1", LastName = "User", UserName ="YS1@dbq.keo.com", Email ="YS1@dbq.keo.com", AssignedLocation ="YS1", AssignedLocationLatLong="", EmailConfirmed = true, PhoneNumberConfirmed = true},"YS1@123"},
{ new ApplicationUser { FirstName = "YS2", LastName = "User", UserName ="YS2@dbq.keo.com", Email ="YS2@dbq.keo.com", AssignedLocation ="YS2", AssignedLocationLatLong="", EmailConfirmed = true, PhoneNumberConfirmed = true},"YS2@123"},
{ new ApplicationUser { FirstName = "GA1", LastName = "User", UserName ="GA1@dbq.keo.com", Email ="GA1@dbq.keo.com", AssignedLocation ="GA1", AssignedLocationLatLong="", EmailConfirmed = true, PhoneNumberConfirmed = true},"GA1@123"},
{ new ApplicationUser { FirstName = "GA2", LastName = "User", UserName ="GA2@dbq.keo.com", Email ="GA2@dbq.keo.com", AssignedLocation ="GA2", AssignedLocationLatLong="", EmailConfirmed = true, PhoneNumberConfirmed = true},"GA2@123"},
{ new ApplicationUser { FirstName = "AD1", LastName = "User", UserName ="AD1@dbq.keo.com", Email ="AD1@dbq.keo.com", AssignedLocation ="AD1", AssignedLocationLatLong="", EmailConfirmed = true, PhoneNumberConfirmed = true},"AD1@123"},
{ new ApplicationUser { FirstName = "AD2", LastName = "User", UserName ="AD2@dbq.keo.com", Email ="AD2@dbq.keo.com", AssignedLocation ="AD2", AssignedLocationLatLong="", EmailConfirmed = true, PhoneNumberConfirmed = true},"AD2@123"},
{ new ApplicationUser { FirstName = "WA1", LastName = "User", UserName ="WA1@dbq.keo.com", Email ="WA1@dbq.keo.com", AssignedLocation ="WA1", AssignedLocationLatLong="", EmailConfirmed = true, PhoneNumberConfirmed = true},"Wa1@123"},
{ new ApplicationUser { FirstName = "WA2", LastName = "User", UserName ="WA2@dbq.keo.com", Email ="WA2@dbq.keo.com", AssignedLocation ="WA2", AssignedLocationLatLong="", EmailConfirmed = true, PhoneNumberConfirmed = true},"WA2@123"},
{ new ApplicationUser { FirstName = "Test1", LastName = "User", UserName ="test1@dbq.keo.com", Email ="test1@dbq.keo.com", AssignedLocation ="Test1", AssignedLocationLatLong="", EmailConfirmed = true, PhoneNumberConfirmed = true},"Test@123"},
{ new ApplicationUser { FirstName = "Test2", LastName = "User", UserName ="test2@dbq.keo.com", Email ="test2@dbq.keo.com", AssignedLocation ="Test2", AssignedLocationLatLong="", EmailConfirmed = true, PhoneNumberConfirmed = true},"Test@123"},

            };
            foreach (var user in users)
            {
                if (!context.Users.Any(u => u.UserName == user.Key.UserName))
                {
                    IdentityResult newUser = userManager.CreateAsync(user.Key, user.Value).Result;
                    if (newUser.Succeeded)
                    {
                        if (user.Key.UserName == "admin@test.com")
                            userManager.AddToRoleAsync(user.Key, Roles.Administrator.ToString()).Wait();
                        else
                            userManager.AddToRoleAsync(user.Key, Roles.Interviewer.ToString()).Wait();
                    }
                }
            }

        }


        public static void SeedQuestions(ApplicationDbContext context)
        {
            List<QuestionType> questionTypes = new List<QuestionType>()
            {
new QuestionType { TypeName = "Single Select", ControlType = "Radio" },//1
new QuestionType { TypeName = "Single Select With Other", ControlType = "Radio" },//2
new QuestionType { TypeName = "Yes/No", ControlType = "Radio" },//3
new QuestionType { TypeName = "Male/Female", ControlType = "Radio" },//4
new QuestionType { TypeName = "Multi Select", ControlType = "Checkbox" },//5
new QuestionType { TypeName = "Open Text", ControlType = "Numeric" },//6
new QuestionType { TypeName = "Section Heading", ControlType = "PlainText" },//7
new QuestionType { TypeName = "Rank", ControlType = "Textbox" },//8
new QuestionType { TypeName = "Rate", ControlType = "PlainText" },//9
new QuestionType { TypeName = "Map", ControlType = "Textbox" },//10

            };
            foreach (QuestionType item in questionTypes)
            {
                if (!context.QuestionTypes.Any(x => x.TypeName == item.TypeName))
                {
                    context.QuestionTypes.Add(item);
                }
            }
            context.SaveChanges();
            List<Question> questions = new List<Question>()
            {

new Question { QuestionTypeId = 7, Text = "OBSERVATIONS", ParentId = null, OrderNum = 1 },
new Question { QuestionTypeId = 4, Text = "Gender?", ParentId = null, OrderNum = 2 },
new Question { QuestionTypeId = 7, Text = "INTERVIEW – Part 1", ParentId = null, OrderNum = 3 },
new Question { QuestionTypeId = 1, Text = "Q1: Age", ParentId = null, OrderNum = 4 },
new Question { QuestionTypeId = 1, Text = "Q2: Nationality", ParentId = null, OrderNum = 5 },
new Question { QuestionTypeId = 1, Text = "Q3: Years Driving in UAE", ParentId = null, OrderNum = 6 },
new Question { QuestionTypeId = 1, Text = "Q4: Driving Frequency", ParentId = null, OrderNum = 7 },
new Question { QuestionTypeId = 1, Text = "Q5: Education Level", ParentId = null, OrderNum = 8 },
new Question { QuestionTypeId = 7, Text = "INTERVIEW – PART 2", ParentId = null, OrderNum = 9 },
new Question { QuestionTypeId = 9, Text = "Attitude", ParentId = null, OrderNum = 10 },
new Question { QuestionTypeId = 1, Text = "Q6: It’s OK to use the mobile whilst driving as long as you drive carefully.", ParentId = 10, OrderNum = 11 },
new Question { QuestionTypeId = 1, Text = "Q7: It is normal to sometimes use a mobile phone while driving because I see many people around me doing it.", ParentId = 10, OrderNum = 12 },
new Question { QuestionTypeId = 1, Text = "Q8: It is acceptable to drive close to the vehicle in front as long as you are careful.", ParentId = 10, OrderNum = 13 },
new Question { QuestionTypeId = 1, Text = "Q9: It's OK to drive faster than the speed limit as long as you drive carefully.", ParentId = 10, OrderNum = 14 },
new Question { QuestionTypeId = 1, Text = "Q10: It is OK to change lanes suddenly as long as you drive within your own capabilities.", ParentId = 10, OrderNum = 15 },
new Question { QuestionTypeId = 1, Text = "Q11: Being involved in an accident is fate and cannot be avoided.", ParentId = 10, OrderNum = 16 },
new Question { QuestionTypeId = 9, Text = "Violations – How often do you…", ParentId = null, OrderNum = 17 },
new Question { QuestionTypeId = 1, Text = "Q12: Send text messages/WhatsApp/short messages when driving.", ParentId = 17, OrderNum = 18 },
new Question { QuestionTypeId = 1, Text = "Q13: Call or make voice chats when driving.", ParentId = 17, OrderNum = 19 },
new Question { QuestionTypeId = 1, Text = "Q14: Become impatient with a slow driver and overtake.", ParentId = 17, OrderNum = 20 },
new Question { QuestionTypeId = 1, Text = "Q15: Drive close to or “flash” the car in front as a signal for the driver in front to go faster or move over.", ParentId = 17, OrderNum = 21 },
new Question { QuestionTypeId = 1, Text = "Q16: Drive over the sign posted speed limits on an expressway.", ParentId = 17, OrderNum = 22 },
new Question { QuestionTypeId = 1, Text = "Q17: Drive over the sign posted speed limit on a residential road.", ParentId = 17, OrderNum = 23 },
new Question { QuestionTypeId = 9, Text = "Errors – How often do you…", ParentId = null, OrderNum = 24 },
new Question { QuestionTypeId = 1, Text = "Q18: Miss seeing traffic signs like “speed signs”, “give way” or “stop” signs.", ParentId = 24, OrderNum = 25 },
new Question { QuestionTypeId = 1, Text = "Q19: Find yourself unsure of the posted speed limit of the road.", ParentId = 24, OrderNum = 26 },
new Question { QuestionTypeId = 1, Text = "Q20: Drive without wearing your seat belt.", ParentId = 24, OrderNum = 27 },
new Question { QuestionTypeId = 1, Text = "Q21: Fail to check your mirrors before pulling out, changing lanes, merging, etc.", ParentId = 24, OrderNum = 28 },
new Question { QuestionTypeId = 9, Text = "Lapses – How often do you…", ParentId = null, OrderNum = 29 },
new Question { QuestionTypeId = 1, Text = "Q22: When driving on a road with pedestrian crossing, fail to notice that pedestrians are crossing the road.", ParentId = 29, OrderNum = 30 },
new Question { QuestionTypeId = 1, Text = "Q23: Check your speedometer, you find that you have been speeding unconsciously.", ParentId = 29, OrderNum = 31 },
new Question { QuestionTypeId = 1, Text = "Q24: While waiting at a traffic signal, fail to notice that the traffic lights have turned green.", ParentId = 29, OrderNum = 32 },

            };
            foreach (Question item in questions)
            {
                if (!context.Questions.Any(x => x.Text == item.Text))
                {
                    context.Questions.Add(item);
                    context.SaveChanges();
                }
            }

            List<Answer> answers = new List<Answer>()
            {

new Answer { QuestionId = 2, AnswerText = "Male", OrderNum = 1 },
new Answer { QuestionId = 2, AnswerText = "Female", OrderNum = 2 },

new Answer { QuestionId = 4, AnswerText = "Under 12", OrderNum = 1 },
new Answer { QuestionId = 4, AnswerText = "13 – 17", OrderNum = 2 },
new Answer { QuestionId = 4, AnswerText = "18 – 24", OrderNum = 3 },
new Answer { QuestionId = 4, AnswerText = "25 – 34", OrderNum = 4 },
new Answer { QuestionId = 4, AnswerText = "35 – 44", OrderNum = 5 },
new Answer { QuestionId = 4, AnswerText = "45 – 54", OrderNum = 6 },
new Answer { QuestionId = 4, AnswerText = "55 – 64", OrderNum = 7 },
new Answer { QuestionId = 4, AnswerText = "65+", OrderNum = 8 },

new Answer { QuestionId = 5, AnswerText = "Emirati", OrderNum = 1 },
new Answer { QuestionId = 5, AnswerText = "Arab (Non-Emirati)", OrderNum = 2 },
new Answer { QuestionId = 5, AnswerText = "African (Non-Arab)", OrderNum = 3 },
new Answer { QuestionId = 5, AnswerText = "Expat South Asian (India, Pakistan, Sri Lanka, Nepal, Bangladesh)", OrderNum = 4 },
new Answer { QuestionId = 5, AnswerText = "Southeast Asian (Philippines, Indonesia, Malaysia, Thailand, Vietnam, Singapore)", OrderNum = 5 },
new Answer { QuestionId = 5, AnswerText = "Europe / Westerner", OrderNum = 6 },
new Answer { QuestionId = 5, AnswerText = "Other Asian", OrderNum = 7 },

new Answer { QuestionId = 6, AnswerText = "Under 2 years", OrderNum = 1 },
new Answer { QuestionId = 6, AnswerText = "2 – 4 years", OrderNum = 2 },
new Answer { QuestionId = 6, AnswerText = "5 – 10 years", OrderNum = 3 },
new Answer { QuestionId = 6, AnswerText = "Over 10 years", OrderNum = 4 },

new Answer { QuestionId = 7, AnswerText = "Daily", OrderNum = 1 },
new Answer { QuestionId = 7, AnswerText = "2 – 3 Times Per Week", OrderNum = 2 },
new Answer { QuestionId = 7, AnswerText = "Once Per Week", OrderNum = 3 },
new Answer { QuestionId = 7, AnswerText = "Once Per Month", OrderNum = 4 },
new Answer { QuestionId = 7, AnswerText = "Less Than Once Per Month", OrderNum = 5 },

new Answer { QuestionId = 8, AnswerText = "Uneducated", OrderNum = 1 },
new Answer { QuestionId = 8, AnswerText = "Primary/Basic", OrderNum = 2 },
new Answer { QuestionId = 8, AnswerText = "Secondary/High School", OrderNum = 3 },
new Answer { QuestionId = 8, AnswerText = "Diploma", OrderNum = 4 },
new Answer { QuestionId = 8, AnswerText = "Bachelors", OrderNum = 5 },
new Answer { QuestionId = 8, AnswerText = "Masters", OrderNum = 6 },
new Answer { QuestionId = 8, AnswerText = "Doctorate", OrderNum = 7 },

new Answer { QuestionId = 10, AnswerText = "Strongly Disagree", OrderNum = 1 },
new Answer { QuestionId = 10, AnswerText = "Disagree", OrderNum = 2 },
new Answer { QuestionId = 10, AnswerText = "Neutral", OrderNum = 3 },
new Answer { QuestionId = 10, AnswerText = "Agree", OrderNum = 4 },
new Answer { QuestionId = 10, AnswerText = "Strongly Agree", OrderNum = 5 },
//new Answer { QuestionId = 10, AnswerText = "Strongly Disagree", OrderNum = 6 },

new Answer { QuestionId = 17, AnswerText = "Never", OrderNum = 1 },
new Answer { QuestionId = 17, AnswerText = "Hardly Ever", OrderNum = 2 },
new Answer { QuestionId = 17, AnswerText = "Occasionally", OrderNum = 3 },
new Answer { QuestionId = 17, AnswerText = "Often", OrderNum = 4 },
new Answer { QuestionId = 17, AnswerText = "Frequently", OrderNum = 5 },
new Answer { QuestionId = 17, AnswerText = "Almost Always", OrderNum = 6 },

new Answer { QuestionId = 24, AnswerText = "Never", OrderNum = 1 },
new Answer { QuestionId = 24, AnswerText = "Hardly Ever", OrderNum = 2 },
new Answer { QuestionId = 24, AnswerText = "Occasionally", OrderNum = 3 },
new Answer { QuestionId = 24, AnswerText = "Often", OrderNum = 4 },
new Answer { QuestionId = 24, AnswerText = "Frequently", OrderNum = 5 },
new Answer { QuestionId = 24, AnswerText = "Almost Always", OrderNum = 6 },

new Answer { QuestionId = 29, AnswerText = "Never", OrderNum = 1 },
new Answer { QuestionId = 29, AnswerText = "Hardly Ever", OrderNum = 2 },
new Answer { QuestionId = 29, AnswerText = "Occasionally", OrderNum = 3 },
new Answer { QuestionId = 29, AnswerText = "Often", OrderNum = 4 },
new Answer { QuestionId = 29, AnswerText = "Frequently", OrderNum = 5 },
new Answer { QuestionId = 29, AnswerText = "Almost Always", OrderNum = 6 },

            };
            foreach (Answer item in answers)
            {
                if (!context.Answers.Any(x => x.AnswerText == item.AnswerText))
                {
                    context.Answers.Add(item);
                }
            }
            context.SaveChanges();

        }
    }
}
