using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fotbol.Web.Data;
using Fotbol.Web.Data.Entities;

namespace Fotbol.Web.Controllers
{
    public class EquipoController : Controller
    {
        private readonly DataContext _context;

        public EquipoController(DataContext context)
        {
            _context = context;
        }

        // GET: Equipo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Equipos.ToListAsync());
        }

        // GET: Equipo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipoEntity = await _context.Equipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipoEntity == null)
            {
                return NotFound();
            }

            return View(equipoEntity);
        }

        // GET: Equipo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Equipo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,LogoPath")] EquipoEntity equipoEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipoEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipoEntity);
        }

        // GET: Equipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipoEntity = await _context.Equipos.FindAsync(id);
            if (equipoEntity == null)
            {
                return NotFound();
            }
            return View(equipoEntity);
        }

        // POST: Equipo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,LogoPath")] EquipoEntity equipoEntity)
        {
            if (id != equipoEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipoEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoEntityExists(equipoEntity.Id))
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
            return View(equipoEntity);
        }

        // GET: Equipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipoEntity = await _context.Equipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipoEntity == null)
            {
                return NotFound();
            }

            return View(equipoEntity);
        }

        // POST: Equipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipoEntity = await _context.Equipos.FindAsync(id);
            _context.Equipos.Remove(equipoEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoEntityExists(int id)
        {
            return _context.Equipos.Any(e => e.Id == id);
        }
    }
}
