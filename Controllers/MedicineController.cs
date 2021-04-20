﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labo3_JonnathanLanuza1082219__CésarSilva1184519.Models.Data;
using Labo3_JonnathanLanuza1082219__CésarSilva1184519.Models;
using Labo3_JonnathanLanuza1082219__CésarSilva1184519.Models.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Configuration;
using System.Web;

namespace Labo3_JonnathanLanuza1082219__CésarSilva1184519.Controllers
{
    public class MedicineController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        public MedicineController(IWebHostEnvironment hostEnvironment)
        {
            hostingEnvironment = hostEnvironment;
        }
        // GET: MedicineController
        public ActionResult Index()
        {
            return View(Singleton.Instance.MClientsList);
        }

        // GET: MedicineController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedicineController/Create
        public ActionResult FileUpload()
        {
            return View();
        }

        // POST: MedicineController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedicineModelsV model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string uniquefilename = null;
                    if (model.SelectList != null)
                    {
                        //Subir archivo
                        string uploadsfolder = Path.Combine(hostingEnvironment.WebRootPath, "Uploads");
                        uniquefilename = Guid.NewGuid().ToString() + "_" + model.SelectList.FileName;
                        string filepath = Path.Combine(uploadsfolder, uniquefilename);
                        model.SelectList.CopyTo(new FileStream(filepath, FileMode.Create));
                        //Leer archivo
                        StreamReader lector = new StreamReader(filepath);
                        while (!lector.EndOfStream)
                        {
                            string leer = lector.ReadLine();
                            //interpretar linea para leer info de medicina

                            
                            //insertar en la lista de medicinas


                            //insertar en el indice de busqueda AVL

                        }

                    };

                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateClient(IFormCollection collection)
        {
            return View();
        }

        // GET: MedicineController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MedicineController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MedicineController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MedicineController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}