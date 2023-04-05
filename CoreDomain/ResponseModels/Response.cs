using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDomain.ResponseModels
{
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public string Token { get; set; }
        public DateTime? Expiration { get; set; }


    }
}
