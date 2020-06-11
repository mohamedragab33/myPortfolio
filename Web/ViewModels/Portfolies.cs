using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class Portfolies
    {
        public Guid id { get; set; }


        public string ProjectName { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public IFormFile file { get; set; }
    }
}
