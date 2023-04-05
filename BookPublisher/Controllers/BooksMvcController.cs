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
    public class BooksMvcController : Controller
    {
        private readonly IBookService bookService;

        public BooksMvcController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        // GET: BooksMvc
        public async Task<IActionResult> Index()
        {
            var books = await bookService.GetAll();
              return books != null ? 
                          View(books.ToList()) :
                          Problem("Entity set 'BookContext.Books'  is null.");
        }

        // GET: BooksMvc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await bookService.Get(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: BooksMvc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BooksMvc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,IBSN,Ano")] Book book)
        {
            if (ModelState.IsValid)
            {
                var result = await bookService.Add(book);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(book);
        }

        // GET: BooksMvc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await bookService.Get(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: BooksMvc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,IBSN,Ano")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await bookService.Update(book);

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }

                return NotFound();
            }
            return View(book);
        }

        // GET: BooksMvc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await bookService.Get(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: BooksMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await bookService.Get(id);
            if (book != null)
            {
                await bookService.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return bookService.Get(id) != null;
        }
    }
}
