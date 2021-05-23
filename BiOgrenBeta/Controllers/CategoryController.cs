using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiOgrenBeta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using PagedList.Core;

namespace BiOgrenBeta.Controllers
{
    [Route("Category")]
    public class CategoryController : Controller
    {
        private readonly Context _db;

        [Route("Courses")]
        [Route("")]
        [Route("~/")]
        public IActionResult Courses(int page =1, int pageSize = 3)
        {
            PagedList<TestClass> model = new PagedList<TestClass>(_db.TestClasses, 1, 2);

            return View("Courses",model);
        }
    }
}
