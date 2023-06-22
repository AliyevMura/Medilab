using MediLab.DAL;
using MediLab.Models;
using MediLab.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediLab.Controllers
{
	public class DoctorController : Controller
	{
        private readonly AppDbContext _context;

        public DoctorController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            DoctorVM doctorVM = new DoctorVM()
            {
                Services = await _context.Types
                .Include(s=>s.Doctors).ToListAsync(),
                Doctors = await _context.Doctors
                .Include(d => d.TypeOfService)
                .OrderByDescending(d => d.Id)
                .ToListAsync()

            };
            return View(doctorVM);
            //return View(await _context.Doctors.Where(p => !p.IsDeleted).OrderByDescending(p => p.Id).ToListAsync());

        }
    }
}
