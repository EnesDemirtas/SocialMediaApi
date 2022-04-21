using CwkSocial.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Application.Models {

    public class Error {
        public ErrorCode Code { get; set; }
        public string Message { get; set; }
    }
}