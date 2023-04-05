using CoreDomain.Constants;
using CoreDomain.DataModels.Internal;
using CoreDomain.DataModels.Questionnaire;
using DataService.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Configuration
{
    public static class Extension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedRoles(modelBuilder);
            SeedUsers(modelBuilder);
            SeedQuestions(modelBuilder);
        }
        public static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = Roles.Administrator.ToString() },
                new IdentityRole { Name = Roles.Interviewer.ToString() },
                new IdentityRole { Name = Roles.AnonymousUser.ToString() }
                );
        }
        public static void SeedUsers(ModelBuilder modelBuilder)
        {
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            var defaultUser = new ApplicationUser {
                FirstName = DefaultUser.default_firstname,
                LastName = DefaultUser.default_lastname,
                UserName = DefaultUser.default_username, 
                Email = DefaultUser.default_email, 
                EmailConfirmed = true, 
                PhoneNumberConfirmed = true };
            defaultUser.PasswordHash = ph.HashPassword(defaultUser, DefaultUser.default_password);

            modelBuilder.Entity<ApplicationUser>().HasData(defaultUser);
        }

        public static void SeedUserRole(ModelBuilder modelBuilder)
        {
            //ToDo assign role to a user
        }


        public static void SeedQuestions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionType>().HasData(
                new QuestionType { TypeName = "Single Select", ControlType = "Radio" },
                new QuestionType { TypeName = "Single Select With Other", ControlType = "Radio" },
                new QuestionType { TypeName = "Yes/No", ControlType = "Radio" },
                new QuestionType { TypeName = "Male/Female", ControlType = "Radio" },
                new QuestionType { TypeName = "Multi Select", ControlType = "Checkbox" },
                new QuestionType { TypeName = "Open Text", ControlType = "Textbox" },
                new QuestionType { TypeName = "None", ControlType = "PlainText" },
                new QuestionType { TypeName = "Rank", ControlType = "Textbox" }

            );
            modelBuilder.Entity<Question>().HasData(
                new Question { QuestionTypeId = 1, Text = "Current mode of travel: (Select only one)", ParentId = null, OrderNum =1 },
                new Question { QuestionTypeId = 4, Text = "Gender?", ParentId = null, OrderNum =2 },
                new Question { QuestionTypeId = 3, Text = "Wearing Helmet?", ParentId = null, OrderNum =3 },
                new Question { QuestionTypeId = 3, Text = "Attached Visible Light?", ParentId = null, OrderNum =4 },
                new Question { QuestionTypeId = 3, Text = "Wearing Reflective Vest?", ParentId = null, OrderNum =5 },
                new Question { QuestionTypeId = 1, Text = "Q1: Age?", ParentId = null, OrderNum =6 },
                new Question { QuestionTypeId = 1, Text = "Q2: What’s your nationality? (Select only one)", ParentId = null, OrderNum =7 },
                new Question { QuestionTypeId = 2, Text = "Q3: What is your current employment status? (Select only one)", ParentId = null, OrderNum =8 },
                new Question { QuestionTypeId = 1, Text = "Q4: How often do you use micro-mobility device? (Select only one)", ParentId = null, OrderNum =9 },
                new Question { QuestionTypeId = 1, Text = "Q5: What is the purpose of your trip today? (Select only one)", ParentId = null, OrderNum =10 },
                new Question { QuestionTypeId = 1, Text = "Q6: What type of transport did you use for this trip before? (Select only one)", ParentId = null, OrderNum =11 },
                new Question { QuestionTypeId = 6, Text = "Q7: What is your destination for this trip?", ParentId = null, OrderNum =12 },
                new Question { QuestionTypeId = 6, Text = "Q8: Where did you start this journey?", ParentId = null, OrderNum =13 },
                new Question { QuestionTypeId = 6, Text = "Q9: Approximately, for how many minutes you will have ridden your bicycle/e-scooter today? (Insert in minutes)", ParentId = null, OrderNum =14 },
                new Question { QuestionTypeId = 7, Text = "Q10: How often do you ride your  micro-mobility device on each of the following facilities? (Rate each)", ParentId = null, OrderNum =15 },
                new Question { QuestionTypeId = 1, Text = "Pavement shared with pedestrians", ParentId = 15, OrderNum =16 },
                new Question { QuestionTypeId = 1, Text = "Off Road shared with vehicles", ParentId = 15, OrderNum =17 },
                new Question { QuestionTypeId = 1, Text = "Dedicated cycle track, segregated from traffic and pedestrians", ParentId = 15, OrderNum =18 },
                new Question { QuestionTypeId = 1, Text = "Sign-posted on-road cycle lane", ParentId = 15, OrderNum =19 },
                new Question { QuestionTypeId = 1, Text = "Sign-posted shared areas with pedestrians", ParentId = 15, OrderNum =20 },
                new Question { QuestionTypeId = 8, Text = "Q11: Rank the facility that will encourage you to use your bike or escooter more often: (Rank from 1 to 6)", ParentId = null, OrderNum =21 },
                new Question { QuestionTypeId = 7, Text = "Q12: How do you perceive the level of safety for each of the following for cyclists/e-scooter riders? (Rate each)", ParentId = null, OrderNum =22 },
                new Question { QuestionTypeId = 1, Text = "Intersection crossing", ParentId = 22, OrderNum =23 },
                new Question { QuestionTypeId = 1, Text = "Interaction with pedestrians", ParentId = 22, OrderNum =24 },
                new Question { QuestionTypeId = 1, Text = "Interaction with other bicycles/scooters", ParentId = 22, OrderNum =25 },
                new Question { QuestionTypeId = 1, Text = "Interaction with vehicles", ParentId = 22, OrderNum =26 },
                new Question { QuestionTypeId = 3, Text = "Q13: Have had an accident or near miss whilst on using Micromobility? (Select only one)", ParentId = null, OrderNum =27 },
                new Question { QuestionTypeId = 3, Text = "Q14: Do you own a car? (Select only one)", ParentId = null, OrderNum =28 },
                new Question { QuestionTypeId = 5, Text = "Q15: Why do you use e-scooters or bicycles instead of cars, taxis, or buses? (Select all that apply)", ParentId = null, OrderNum =29 },
                new Question { QuestionTypeId = 1, Text = "Q16: How often do you use public buses to commute? (Select only one)", ParentId = null, OrderNum =30 },
                new Question { QuestionTypeId = 1, Text = "Q17: Will it encourage you to use buses more frequently in case you were able to carry your micro-mobility device on buses so you don’t have to walk to/from the bus station? (Select only one)", ParentId = null, OrderNum =31 }

            );

            modelBuilder.Entity<Answer>().HasData(
                new Answer { QuestionId = 1, AnswerText = "Bicycle", OrderNum = 1 },
                new Answer { QuestionId = 1, AnswerText = "e-Bicycle", OrderNum = 2 },
                new Answer { QuestionId = 1, AnswerText = "Small E-scooter with Saddles", OrderNum = 3 },
                new Answer { QuestionId = 1, AnswerText = "Large E-scooter", OrderNum = 4 },
                new Answer { QuestionId = 1, AnswerText = "Hoverboard/Mini-Segways/Unicycles", OrderNum = 5 },
                new Answer { QuestionId = 1, AnswerText = "Small E-scooter", OrderNum = 6 },
                new Answer { QuestionId = 1, AnswerText = "Medium E-scooter", OrderNum = 7 },
                new Answer { QuestionId = 1, AnswerText = "Customised Leisure E-Scooter", OrderNum = 8 },
                new Answer { QuestionId = 1, AnswerText = "Skateboard", OrderNum = 9 },

                new Answer { QuestionId = 2, AnswerText = "Male", OrderNum = 1 },
                new Answer { QuestionId = 2, AnswerText = "Female", OrderNum = 2 },

                new Answer { QuestionId = 3, AnswerText = "Yes", OrderNum = 1 },
                new Answer { QuestionId = 3, AnswerText = "No", OrderNum = 2 },

                new Answer { QuestionId = 4, AnswerText = "Yes", OrderNum = 1 },
                new Answer { QuestionId = 4, AnswerText = "No", OrderNum = 2 },

                new Answer { QuestionId = 5, AnswerText = "Yes", OrderNum = 1 },
                new Answer { QuestionId = 5, AnswerText = "No", OrderNum = 2 },

                new Answer { QuestionId = 6, AnswerText = "Under 12", OrderNum = 1 },
                new Answer { QuestionId = 6, AnswerText = "13 – 17", OrderNum = 2 },
                new Answer { QuestionId = 6, AnswerText = "18 – 24", OrderNum = 3 },
                new Answer { QuestionId = 6, AnswerText = "25 – 34", OrderNum = 4 },
                new Answer { QuestionId = 6, AnswerText = "35 – 44", OrderNum = 5 },
                new Answer { QuestionId = 6, AnswerText = "35 – 44", OrderNum = 6 },
                new Answer { QuestionId = 6, AnswerText = "55 – 64", OrderNum = 7 },
                new Answer { QuestionId = 6, AnswerText = "65+", OrderNum = 8 },

                new Answer { QuestionId = 7, AnswerText = "Emirati", OrderNum = 1 },
                new Answer { QuestionId = 7, AnswerText = "Arab (Non-Emirati)", OrderNum = 2 },
                new Answer { QuestionId = 7, AnswerText = "Europe / Western", OrderNum = 3 },
                new Answer { QuestionId = 7, AnswerText = "India, Pakistan or Bangladesh", OrderNum = 4 },
                new Answer { QuestionId = 7, AnswerText = "Philippines", OrderNum = 5 },
                new Answer { QuestionId = 7, AnswerText = "African but not Arab", OrderNum = 6 },
                new Answer { QuestionId = 7, AnswerText = "Other Asian", OrderNum = 7 },

                new Answer { QuestionId = 8, AnswerText = "Student", OrderNum = 1 },
                new Answer { QuestionId = 8, AnswerText = "Full-time Employed", OrderNum = 2 },
                new Answer { QuestionId = 8, AnswerText = "Part-time Employed", OrderNum = 3 },
                new Answer { QuestionId = 8, AnswerText = "Unemployed", OrderNum = 4 },
                new Answer { QuestionId = 8, AnswerText = "Homemaker / Housewife", OrderNum = 5 },
                new Answer { QuestionId = 8, AnswerText = "Retired", OrderNum = 6 },
                new Answer { QuestionId = 8, AnswerText = "Other", OrderNum = 7 },

                new Answer { QuestionId = 9, AnswerText = "More Than Once Daily", OrderNum = 1 },
                new Answer { QuestionId = 9, AnswerText = "More Than Once Per Week", OrderNum = 2 },
                new Answer { QuestionId = 9, AnswerText = "More Than Once Per Month", OrderNum = 3 },
                new Answer { QuestionId = 9, AnswerText = "Occasionally", OrderNum = 4 },
                new Answer { QuestionId = 9, AnswerText = "Once Daily", OrderNum = 5 },
                new Answer { QuestionId = 9, AnswerText = "Once A Week", OrderNum = 6 },
                new Answer { QuestionId = 9, AnswerText = "Once Per Month", OrderNum = 7 },
                new Answer { QuestionId = 9, AnswerText = "More Than Once Per Week During Winter And Spring Only", OrderNum = 8 },

                new Answer { QuestionId = 10, AnswerText = "Work", OrderNum = 1 },
                new Answer { QuestionId = 10, AnswerText = "Sports/Fitness", OrderNum = 2 },
                new Answer { QuestionId = 10, AnswerText = "Food/Restaurant", OrderNum = 3 },
                new Answer { QuestionId = 10, AnswerText = "School/University", OrderNum = 4 },
                new Answer { QuestionId = 10, AnswerText = "Tourism", OrderNum = 5 },
                new Answer { QuestionId = 10, AnswerText = "Errands", OrderNum = 6 },
                new Answer { QuestionId = 10, AnswerText = "Mosque", OrderNum = 7 },
                new Answer { QuestionId = 10, AnswerText = "Food/product delivery", OrderNum = 8 },
                new Answer { QuestionId = 10, AnswerText = "Leisure/Recreation", OrderNum = 9 },
                new Answer { QuestionId = 10, AnswerText = "Shopping", OrderNum = 10 },
                new Answer { QuestionId = 10, AnswerText = "Medical", OrderNum = 11 },

                new Answer { QuestionId = 11, AnswerText = "Car as Driver", OrderNum = 1 },
                new Answer { QuestionId = 11, AnswerText = "Car as Passenger", OrderNum = 2 },
                new Answer { QuestionId = 11, AnswerText = "Bicycle", OrderNum = 3 },
                new Answer { QuestionId = 11, AnswerText = "Motorcycle", OrderNum = 4 },
                new Answer { QuestionId = 11, AnswerText = "Bus", OrderNum = 5 },
                new Answer { QuestionId = 11, AnswerText = "Walk", OrderNum = 6 },
                new Answer { QuestionId = 11, AnswerText = "Taxi", OrderNum = 7 },
                new Answer { QuestionId = 11, AnswerText = "E-Scooter", OrderNum = 8 },
                new Answer { QuestionId = 11, AnswerText = "Jogging", OrderNum = 9 },
                new Answer { QuestionId = 11, AnswerText = "Skating", OrderNum = 10 },
                new Answer { QuestionId = 11, AnswerText = "I have no other option", OrderNum = 11 },

                new Answer { QuestionId = 16, AnswerText = "None", OrderNum = 1 },
                new Answer { QuestionId = 16, AnswerText = "Rarely", OrderNum = 2 },
                new Answer { QuestionId = 16, AnswerText = "Sometimes", OrderNum = 3 },
                new Answer { QuestionId = 16, AnswerText = "Frequently", OrderNum = 4 },
                new Answer { QuestionId = 16, AnswerText = "Always", OrderNum = 5 },

                new Answer { QuestionId = 17, AnswerText = "None", OrderNum = 1 },
                new Answer { QuestionId = 17, AnswerText = "Rarely", OrderNum = 2 },
                new Answer { QuestionId = 17, AnswerText = "Sometimes", OrderNum = 3 },
                new Answer { QuestionId = 17, AnswerText = "Frequently", OrderNum = 4 },
                new Answer { QuestionId = 17, AnswerText = "Always", OrderNum = 5 },

                new Answer { QuestionId = 18, AnswerText = "None", OrderNum = 1 },
                new Answer { QuestionId = 18, AnswerText = "Rarely", OrderNum = 2 },
                new Answer { QuestionId = 18, AnswerText = "Sometimes", OrderNum = 3 },
                new Answer { QuestionId = 18, AnswerText = "Frequently", OrderNum = 4 },
                new Answer { QuestionId = 18, AnswerText = "Always", OrderNum = 5 },

                new Answer { QuestionId = 19, AnswerText = "None", OrderNum = 1 },
                new Answer { QuestionId = 19, AnswerText = "Rarely", OrderNum = 2 },
                new Answer { QuestionId = 19, AnswerText = "Sometimes", OrderNum = 3 },
                new Answer { QuestionId = 19, AnswerText = "Frequently", OrderNum = 4 },
                new Answer { QuestionId = 19, AnswerText = "Always", OrderNum = 5 },

                new Answer { QuestionId = 20, AnswerText = "None", OrderNum = 1 },
                new Answer { QuestionId = 20, AnswerText = "Rarely", OrderNum = 2 },
                new Answer { QuestionId = 20, AnswerText = "Sometimes", OrderNum = 3 },
                new Answer { QuestionId = 20, AnswerText = "Frequently", OrderNum = 4 },
                new Answer { QuestionId = 20, AnswerText = "Always", OrderNum = 5 },

                new Answer { QuestionId = 21, AnswerText = "Dedicated cycle track, segregated from traffic and pedestrians", OrderNum = 1 },
                new Answer { QuestionId = 21, AnswerText = "Wider footpaths", OrderNum = 2 },
                new Answer { QuestionId = 21, AnswerText = "Sign-posted on-road cycle lanes", OrderNum = 3 },
                new Answer { QuestionId = 21, AnswerText = "Sign-posted shared areas with pedestrians", OrderNum = 4 },
                new Answer { QuestionId = 21, AnswerText = "Wider central islands at crossings", OrderNum = 5 },
                new Answer { QuestionId = 21, AnswerText = "Parking provisions for bikes and escooters", OrderNum = 6 },

                new Answer { QuestionId = 23, AnswerText = "Very Unsafe", OrderNum = 1 },
                new Answer { QuestionId = 23, AnswerText = "Unsafe", OrderNum = 2 },
                new Answer { QuestionId = 23, AnswerText = "Neutral", OrderNum = 3 },
                new Answer { QuestionId = 23, AnswerText = "Safe", OrderNum = 4 },
                new Answer { QuestionId = 23, AnswerText = "Very Safe", OrderNum = 5 },

                new Answer { QuestionId = 24, AnswerText = "Very Unsafe", OrderNum = 1 },
                new Answer { QuestionId = 24, AnswerText = "Unsafe", OrderNum = 2 },
                new Answer { QuestionId = 24, AnswerText = "Neutral", OrderNum = 3 },
                new Answer { QuestionId = 24, AnswerText = "Safe", OrderNum = 4 },
                new Answer { QuestionId = 24, AnswerText = "Very Safe", OrderNum = 5 },

                new Answer { QuestionId = 25, AnswerText = "Very Unsafe", OrderNum = 1 },
                new Answer { QuestionId = 25, AnswerText = "Unsafe", OrderNum = 2 },
                new Answer { QuestionId = 25, AnswerText = "Neutral", OrderNum = 3 },
                new Answer { QuestionId = 25, AnswerText = "Safe", OrderNum = 4 },
                new Answer { QuestionId = 25, AnswerText = "Very Safe", OrderNum = 5 },

                new Answer { QuestionId = 26, AnswerText = "Very Unsafe", OrderNum = 1 },
                new Answer { QuestionId = 26, AnswerText = "Unsafe", OrderNum = 2 },
                new Answer { QuestionId = 26, AnswerText = "Neutral", OrderNum = 3 },
                new Answer { QuestionId = 26, AnswerText = "Safe", OrderNum = 4 },
                new Answer { QuestionId = 26, AnswerText = "Very Safe", OrderNum = 5 },

                new Answer { QuestionId = 27, AnswerText = "Yes", OrderNum = 1 },
                new Answer { QuestionId = 27, AnswerText = "No", OrderNum = 2 },

                new Answer { QuestionId = 28, AnswerText = "Yes", OrderNum = 1 },
                new Answer { QuestionId = 28, AnswerText = "No", OrderNum = 2 },

                new Answer { QuestionId = 29, AnswerText = "I don’t own a car", OrderNum = 1 },
                new Answer { QuestionId = 29, AnswerText = "It’s healthier", OrderNum = 2 },
                new Answer { QuestionId = 29, AnswerText = "No public transport service near me", OrderNum = 3 },
                new Answer { QuestionId = 29, AnswerText = "It’s the cheapest way to travel", OrderNum = 4 },
                new Answer { QuestionId = 29, AnswerText = "It’s more pleasant", OrderNum = 5 },
                new Answer { QuestionId = 29, AnswerText = "It is better than walking (faster and less sweaty).", OrderNum = 6 },

                new Answer { QuestionId = 30, AnswerText = "More Than Once Daily", OrderNum = 1 },
                new Answer { QuestionId = 30, AnswerText = "More Than Once Per Week", OrderNum = 2 },
                new Answer { QuestionId = 30, AnswerText = "More Than Once Per Month", OrderNum = 3 },
                new Answer { QuestionId = 30, AnswerText = "Occasionally", OrderNum = 4 },
                new Answer { QuestionId = 30, AnswerText = "Once Daily", OrderNum = 5 },
                new Answer { QuestionId = 30, AnswerText = "Once A Week", OrderNum = 6 },
                new Answer { QuestionId = 30, AnswerText = "Once Per Month", OrderNum = 7 },
                new Answer { QuestionId = 30, AnswerText = "Never", OrderNum = 8 },

                new Answer { QuestionId = 31, AnswerText = "Would not make a difference", OrderNum = 1 },
                new Answer { QuestionId = 31, AnswerText = "Certainly yes", OrderNum = 2 },
                new Answer { QuestionId = 31, AnswerText = "Maybe", OrderNum = 3 }
            );
        }
    }
}
