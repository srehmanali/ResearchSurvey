using CoreDomain.Constants;
using CoreDomain.DataModels.Questionnaire;
using CoreDomain.ViewModels.SurveyModel;
using DataService.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        ApplicationDbContext context;


        public AdminController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AjaxMethod()
        {
            List<ResponseDTO> data = context.Responses
                                    .GroupJoin(
                                        context.Users,
                                        response => response.UserId,
                                        user => user.Id,
                                        (rs, us) => new { response = rs, user = us }
                                    )
                                    .SelectMany(
                                       x => x.user.DefaultIfEmpty(),
                                       (x, y) => new { response = x.response, user = y })
                                    .OrderBy(o => o.response.CreateDate)
                                    .Select(res => new ResponseDTO()
                                    {
                                        Username = res.user.FirstName + " " + res.user.LastName,
                                        AssignedLocation = res.user.AssignedLocation,
                                        //AssignedLocationLatLong = res.user.AssignedLocationLatLong,
                                        LatLong = res.response.LatLong,
                                        O1 = res.response.O1,
                                        Q1 = res.response.Q1,
                                        Q2 = res.response.Q2,
                                        Q3 = res.response.Q3,
                                        Q4 = res.response.Q4,
                                        Q5 = res.response.Q5,
                                        Q6 = res.response.Q6,
                                        Q7 = res.response.Q7,
                                        Q8 = res.response.Q8,
                                        Q9 = res.response.Q9,
                                        Q10 = res.response.Q10,
                                        Q11 = res.response.Q11,
                                        Q12 = res.response.Q12,
                                        Q13 = res.response.Q13,
                                        Q14 = res.response.Q14,
                                        Q15 = res.response.Q15,
                                        Q16 = res.response.Q16,
                                        Q17 = res.response.Q17,
                                        Q18 = res.response.Q18,
                                        Q19 = res.response.Q19,
                                        Q20 = res.response.Q20,
                                        Q21 = res.response.Q21,
                                        Q22 = res.response.Q22,
                                        Q23 = res.response.Q23,
                                        Q24 = res.response.Q24,
                                        StartTime = res.response.StartTime,
                                        EndTime = res.response.EndTime,
                                        CreateDate = res.response.CreateDate,
                                        SurveyStatus = res.response.SurveyStatus
                                    }).ToList();

            //List<ResponseDTO> data = context.Responses.OrderBy(o => o.CreateDate).ToList();

            return Json(data);
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
