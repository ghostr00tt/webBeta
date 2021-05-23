using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BiOgrenBeta.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BiOgrenBeta.Controllers
{
    public class IndexController : Controller
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public IndexController(Context cnt,IWebHostEnvironment hostEnvironment)
        {
            _context = cnt;
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ScreenRecord()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([Bind("CourseID,CourseName,MentorID,CourseDescription,VideoURL")] Course c)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(c.VideoURL.FileName);
                string extension = Path.GetExtension(c.VideoURL.FileName);
                fileName = "Video" + Guid.NewGuid()+DateTime.Now.ToString()+extension;
                string path = Path.Combine(wwwRootPath + "/Contents/Video", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create)) 
                {
                    await c.VideoURL.CopyToAsync(fileStream);
                }

                _context.Add(c);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AddCourse));
                
            }
            return View(c);
        }
        [HttpGet]

        public async Task<IActionResult> Courses()
        {
            ViewData["CategoryID"] = new SelectList(_context.CourseCategories, "CategoryID", "CategoryName");
            return View(await _context.TestClasses.ToListAsync());
        }

        
        public IActionResult AddCourse()
        {
         
            return View();
        }
    }
}
