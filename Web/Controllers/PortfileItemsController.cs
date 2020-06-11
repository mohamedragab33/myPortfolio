using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure;

namespace Web.Controllers
{
    public class PortfileItemsController : Controller
    {
        private readonly AppDbContext _context;

        public PortfileItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PortfileItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.PortfileItems.ToListAsync());
        }

        // GET: PortfileItems/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfileItems = await _context.PortfileItems
                .FirstOrDefaultAsync(m => m.id == id);
            if (portfileItems == null)
            {
                return NotFound();
            }

            return View(portfileItems);
        }

        // GET: PortfileItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PortfileItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectName,ImgUrl,Description,id")] PortfileItems portfileItems)
        {
            if (ModelState.IsValid)
            {
                portfileItems.id = Guid.NewGuid();
                _context.Add(portfileItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(portfileItems);
        }

        // GET: PortfileItems/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfileItems = await _context.PortfileItems.FindAsync(id);
            if (portfileItems == null)
            {
                return NotFound();
            }
            return View(portfileItems);
        }

        // POST: PortfileItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProjectName,ImgUrl,Description,id")] PortfileItems portfileItems)
        {
            if (id != portfileItems.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portfileItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfileItemsExists(portfileItems.id))
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
            return View(portfileItems);
        }

        // GET: PortfileItems/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfileItems = await _context.PortfileItems
                .FirstOrDefaultAsync(m => m.id == id);
            if (portfileItems == null)
            {
                return NotFound();
            }

            return View(portfileItems);
        }

        // POST: PortfileItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var portfileItems = await _context.PortfileItems.FindAsync(id);
            _context.PortfileItems.Remove(portfileItems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortfileItemsExists(Guid id)
        {
            return _context.PortfileItems.Any(e => e.id == id);
        }
    }
}
