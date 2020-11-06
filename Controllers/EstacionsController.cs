using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using leafletDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace leafletDemo.Controllers
{
    public class EstacionsController : Controller
    {
        private readonly EstacionsContext _context;
        List<Estacions> llistaEstacions = new List<Estacions>();

        public EstacionsController()
        {
            var optionsBuilder = new DbContextOptionsBuilder<EstacionsContext>();
            optionsBuilder.UseMySQL("server=hermes;port=3306;database=estacions;uid=estacio;password=estacio");
            _context = new EstacionsContext(optionsBuilder.Options);
        }

        EstacionsDataAccessLayer objecteEstacions = new EstacionsDataAccessLayer();

        // [HttpGet]
        // public IActionResult Details(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     Estacions estacions = objecteEstacions.GetEstacionsData(id);

        //     if (estacions == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(estacions);
        // }

        public IActionResult Index()
        {
            llistaEstacions = _context.Estacio.Where(x => x.dateTime == 1545629280).ToList();
            // EstacionsDataAccessLayer e = new EstacionsDataAccessLayer();
            // llistaEstacions = objecteEstacions.GetAllEstacions().ToList();
            // DataConvert(llistaEstacions);
            return View(llistaEstacions);
        }



        // public void DataConvert(List<Estacions> llistaEstacions)
        // {
        //     DateTime dataHuma = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        //     foreach (Estacions e in llistaEstacions)
        //     {
        //         e.dataHuma = dataHuma.AddSeconds(e.dateTime);
        //     }
        // }


    }
}