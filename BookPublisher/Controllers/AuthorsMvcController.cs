using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookPublisher.Data;
using BookPublisher.Model;
using BookPublisher.Service;

namespace BookPublisher.Controllers
{
    public class AuthorsMvcController : Controller
    {
        private readonly IAuthorService authorService;

        public AuthorsMvcController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        // GET: AuthorsMvc
        public async Task<IActionResult> Index()
        {
            var authors = await authorService.GetAll();
            return authors != null ?
                        View(authors.ToList()) :
                        Problem("Entity set 'BookContext.Authors'  is null.");
        }

        // GET: AuthorsMvc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author= await authorService.Get(id.Value);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // GET: AuthorsMvc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AuthorsMvc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Email,DataNascimento")] Author author)
        {
            if (ModelState.IsValid)
            {
                var result = await authorService.Add(author);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(author);
        }

        // GET: AuthorsMvc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await authorService.Get(id.Value);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: AuthorsMvc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,Email,DataNascimento")] Author author)
        {
            if (id != author.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await authorService.Update(author);

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }

                return NotFound();
            }
            return View(author);
        }

        // GET: AuthorsMvc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await authorService.Get(id.Value);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: AuthorsMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await authorService.Get(id);
            if (author != null)
            {
                await authorService.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id)
        {
            return authorService.Get(id) != null;
        }
    }
}
