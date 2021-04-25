using Microsoft.AspNetCore.Http;
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

        public ActionResult Search()
        {
            return View(Singleton.Instance.MClientsList);
        }
        [HttpPost]
        public ActionResult Search(string Name, int Id)
        {
            ViewData["SearchName"] = Name;
            ViewData["SearchId"] = Id;
            Singleton.Instance.MClientsList.Clear();

            if (Name != null)
            {
                for (int i = 0; i < Singleton.Instance.MClientsList.Count() - 1; i++)
                {
                    if (Singleton.Instance.MClientsList[i].Name == Name)
                    {
                        Singleton.Instance.MClientsList.Add(Singleton.Instance.MClientsList[i]);
                    }
                }
                return View(Singleton.Instance.MClientsList);
            }
            if (Id > 0)
            {
                for (int i = 0; i < Singleton.Instance.MClientsList.Count() - 1; i++)
                {
                    if (Singleton.Instance.MClientsList[i].Id == Id)
                    {
                        Singleton.Instance.MClientsList.Add(Singleton.Instance.MClientsList[i]);
                    }
                }
                return View(Singleton.Instance.MClientsList);
            }
            else
            {
                return RedirectToAction("Index");
            }
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
                        StreamReader lector = new StreamReader("filepath");
                        //interpretar linea para leer info de medicina
                        string read = lector.ReadLine();
                        int cont = 0;
                        //insertar en la lista de medicinas
                        while (!lector.EndOfStream)
                        {
                            string leer = lector.ReadLine();
                            for (int i = 0; i < 6; i++)
                            {
                                if (read[i] == ',')
                                { 
                                    if (read[i + 1] != ',')
                                    {
                                        //Singleton.Instance.MClientsList[cont] = Convert.ChangeType(read, Medicine);
                                    }
                                    else
                                    {
                                        //Singleton.Instance.MClientsList[cont] = Convert.ChangeType(read, Medicine);
                                    }
                                    cont++;
                                }
                            }

                            //insertar en el indice de busqueda AVL
                            //AVLTree.Add(Singleton.Instance.MClientsList);
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
        public ActionResult Invoice()
        {
            return View();
        }
        public ActionResult EndInvoice()
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
