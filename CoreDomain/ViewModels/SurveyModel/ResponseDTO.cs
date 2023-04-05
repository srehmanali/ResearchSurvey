using CoreDomain.DataModels.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDomain.ViewModels.SurveyModel
{
    public class ResponseDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string LatLong { get; set; }
        public string O1 { get; set; }
        public string Q1 { get; set; }
        public string Q2 { get; set; }
        public string Q3 { get; set; }
        public string Q4 { get; set; }
        public string Q5 { get; set; }

        public string Q6 { get; set; }
        public string Q7 { get; set; }
        public string Q8 { get; set; }
        public string Q9 { get; set; }
        public string Q10 { get; set; }
        public string Q11 { get; set; }
        public string Q12 { get; set; }
        public string Q13 { get; set; }
        public string Q14 { get; set; }
        public string Q15 { get; set; }
        public string Q16 { get; set; }
        public string Q17 { get; set; }
        public string Q18 { get; set; }
        public string Q19 { get; set; }
        public string Q20 { get; set; }
        public string Q21 { get; set; }
        public string Q22 { get; set; }
        public string Q23 { get; set; }
        public string Q24 { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreateDate { get; set; }
        public ApplicationUser User { get; set; }
        public string AssignedLocation { get; set; }
        public string AssignedLocationLatLong { get; set; }
        public string SurveyStatus { get; set; }
    }
}
