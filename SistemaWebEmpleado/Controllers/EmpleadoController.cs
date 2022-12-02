using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        // GET: /empleado/ListaPorTitulo/titulo
        public IActionResult ListaPorTitulo(string titulo)
        {
            List<Empleado> lista = (from p in _context.Empleados
                                  where p.Titulo == titulo
                                  select p).ToList();
            return View("Index", lista);
        }


        //GET:/Empleado/Delete/id
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);
            return View("Delete", empleado);
        }

        // POST: /Empleado/Delete
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }



        //GET:Empleado/Edit/id
        public IActionResult Edit(int id)
        {

            Empleado empleado = _context.Empleados.Find(id);
           
            return View("Edit", empleado);

        }


        //POST : Empleado/Edit/id
        [HttpPost]
        public IActionResult Edit(Empleado empleado)
        {

            if (ModelState.IsValid)
            {

                _context.Entry(empleado).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleado);

        }

        [HttpGet("/empleado/Details/{id}")]
        //GET:
        public IActionResult Details(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);

            return View(empleado);    
        }


    }
}
