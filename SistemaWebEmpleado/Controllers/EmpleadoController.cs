using Microsoft.AspNetCore.Mvc;
using SistemaWebEmpleado.Data;
using SistemaWebEmpleado.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaWebEmpleado.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly EmpleadoContext _context;

        public EmpleadoController(EmpleadoContext context)
        {
            _context = context;
        }

        //GET:Lista de empleados
        public IActionResult Index()
        {

            return View(_context.Empleados.ToList());
        }


        //GET
        public IActionResult Create()
        {
            Empleado empleado = new Empleado();
            return View("Create", empleado);
        }

        // POST: /Empleado/Create
        [HttpPost]
        public IActionResult Create(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", empleado);
            }
            else
            {
                _context.Empleados.Add(empleado);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet("/empleado/ListaPorTitulo/{titulo}")]
        // GET: /person/ListaPorTitulo/titulo
        public IActionResult ListaPorTitulo(string titulo)
        {
            List<Empleado> lista = (from p in _context.Empleados
                                  where p.Titulo == titulo
                                  select p).ToList();
            return View("Index", lista);
        }
    }
}
