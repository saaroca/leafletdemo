using System;
using System.Windows;
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

        public IActionResult Index()
        {
            InitializeDatePicker();
            FindDate();
            return View(llistaEstacions);
        }


        public void InitializeDatePicker()
        {
            // DatePicker datePickerFor2009 = new DatePicker();
            // datePickerFor2009.SelectedDate = new DateTime(2009, 3, 23);
            // datePickerFor2009.DisplayDateStart = new DateTime(2009, 1, 1);
            // datePickerFor2009.DisplayDateEnd = new DateTime(2009, 12, 31);
            // datePickerFor2009.SelectedDateFormat = DatePickerFormat.Long;
            // datePickerFor2009.FirstDayOfWeek = DayOfWeek.Monday;

        }
        public void FindDate()
        {
            llistaEstacions = _context.Estacio.Where(x => x.dateTime == 1512968400).ToList();
            DataConvertHuman(llistaEstacions);
            FarenheitToCelsius(llistaEstacions);
        }

        public void FarenheitToCelsius(List<Estacions> llistaEstacions)
        {

            //Ho fa arrodonit sense decimals
            foreach (Estacions e in llistaEstacions)
            {
                e.inTemp = Convert.ToInt32(5.0 / 9.0 * (e.inTemp - 32));
                e.outTemp = Convert.ToInt32(5.0 / 9.0 * (e.outTemp - 32));
            }
        }

        public void DataConvertHuman(List<Estacions> llistaEstacions)
        {
            DateTime dataHuma = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            foreach (Estacions e in llistaEstacions)
            {
                e.dataHuma = dataHuma.AddSeconds(Convert.ToDouble((e.dateTime)));
            }
        }

        public static long ToEpoch(DateTime dateTime) => (long)(dateTime - new DateTime(1970, 1, 1)).TotalSeconds;


    }
}