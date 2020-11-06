using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using leafletDemo.Models;

namespace leafletDemo.Controllers
{
    public class EstacionsController : Controller
    {

        EstacionsDataAccessLayer objecteEstacions = new EstacionsDataAccessLayer();
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Estacions estacions = objecteEstacions.GetEstacionsData(id);

            if (estacions == null)
            {
                return NotFound();
            }
            return View(estacions);
        }

        public IActionResult Index()
        {
            List<Estacions> llistaEstacions = new List<Estacions>();
            llistaEstacions = objecteEstacions.GetAllEstacions().ToList();
            return View(llistaEstacions);
        }


    }
}