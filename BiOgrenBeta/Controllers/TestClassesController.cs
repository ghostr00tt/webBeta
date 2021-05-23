using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BiOgrenBeta.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BiOgrenBeta.Controllers
{
    public class TestClassesController : Controller
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _env;


        public TestClassesController(Context context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: TestClasses
        public async Task<IActionResult> Index()
        {
            ViewData["CategoryID"] = new SelectList(_context.CourseCategories, "CategoryID", "CategoryName");
            return View(await _context.TestClasses.ToListAsync());
        }

        // GET: TestClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testClass = await _context.TestClasses
                .FirstOrDefaultAsync(m => m.VideoID == id);
            if (testClass == null)
            {
                return NotFound();
            }

            return View(testClass);
        }

        // GET: TestClasses/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.CourseCategories, "CategoryID", "CategoryName");
            return View();

        }

        // POST: TestClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile iform, TestClass item)
        {
            
            
                IFormFile video = item.VideoURL;
                string extension = Path.GetExtension(video.FileName);
                string newFileName = Guid.NewGuid().ToString();
                if (video.Length > 0)
                {
                    string filePath = Path.Combine("C:/Users/asus k555l/source/repos/BiOgrenBeta/BiOgrenBeta/wwwroot/Contents/Videos"
                                                   , newFileName + extension);


                    item.VideoPath = "Contents/Videos/" + newFileName + extension;
                    //write file to file system
                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        await video.CopyToAsync(fs);
                    }
                    //save location to database (in URL format)
                    await _context.AddAsync(item);
                    await _context.SaveChangesAsync();
                ViewData["CategoryID"] = new SelectList(_context.CourseCategories, "CategoryID", "CategoryName", item.CategoryID);
                return RedirectToAction("Index", "TestClasses");
                }
              //  ViewData["MentorID"] = new SelectList(_context.Mentors, "MentorID", "MentorDepartment", course.MentorID);
           
            return View(item);
            
           

        }
            // GET: TestClasses/Edit/5
            public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testClass = await _context.TestClasses.FindAsync(id);
            if (testClass == null)
            {
                return NotFound();
            }
            return View(testClass);
        }

        // POST: TestClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VideoID,VideoName,VideoPath")] TestClass testClass)
        {
            if (id != testClass.VideoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestClassExists(testClass.VideoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(testClass);
        }

        // GET: TestClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testClass = await _context.TestClasses
                .FirstOrDefaultAsync(m => m.VideoID == id);
            if (testClass == null)
            {
                return NotFound();
            }

            return View(testClass);
        }

        // POST: TestClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testClass = await _context.TestClasses.FindAsync(id);
            _context.TestClasses.Remove(testClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestClassExists(int id)
        {
            return _context.TestClasses.Any(e => e.VideoID == id);
        }
    }
}
