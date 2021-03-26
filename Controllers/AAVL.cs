using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.IO;
using Labo3_JonnathanLanuza1082219__CésarSilva1184519.Models.Data;
using Labo3_JonnathanLanuza1082219__CésarSilva1184519.Models;
using Labo3_JonnathanLanuza1082219__CésarSilva1184519.Models.ViewModels;
using System.Threading;
using Microsoft.AspNetCore.Hosting;

namespace Labo3_JonnathanLanuza1082219__CésarSilva1184519.Controllers
{
    public class AAVL : Controller
    {
        List<Medicine> Mclients = new List<Medicine>();
        // GET: AB
        public ActionResult Index()
        {
            return View(Singleton.Instance.MClientsList);
        }

        //Busqueda por nombre
        [HttpPost]
        public ActionResult Index(string Name)
        {
            ViewData["SearchName"] = Name;
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
                return View(Singleton.Instance.SecondMClientsList);
            }
            return View();
        }

        //Reabastecimiento 
        [HttpPost]
        public ActionResult Index(int Ex)
        {
            ViewData["Resupply"] = Ex;
            Singleton.Instance.MClientsList.Clear();

            if (Ex == 0)
            {
                for (int i = 0; i < Singleton.Instance.MClientsList.Count() - 1; i++)
                {
                    if (Singleton.Instance.MClientsList[i].Existence == Ex)
                    {
                        Singleton.Instance.MClientsList.Add(Singleton.Instance.MClientsList[i]);
                        Medicine mednew = new Medicine();
                        //BinaryTree.Insert(Convert.ToInt32(mednew.Id));++++++++++++++++++++++++++++
                        int? search = Convert.ToInt32(Mclients.Find(x => x.Existence == 0));
                        if (search == 0)
                        {
                            Random newex = new Random();
                            search = newex.Next(0, 15);
                        }
                    }
                }
                return View(Singleton.Instance.SecondMClientsList);
            }
            return View();
        }

        public interface IFormFile
        {
            public int? Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Product { get; set; }
            public int Price { get; set; }
            public int? existence { get; set; }
            Stream OpenReadStream();
            void CopyTo(Stream target);
            //Task CopyToAsync(Stream target, CancellationToken cancellationToken = null);
        }

        // GET: AB/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AB/Create

        //Busqueda archivo CSV y creaccion de archivos de ingreso de datos de usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedicineModelsV model, IFormCollection collection)
        {
            try
            {
                string ufilename = null;
                if (model.SelectList != null)
                {
                    ufilename = Guid.NewGuid().ToString() + "_" + model.SelectList.FileName;
                    string filepath = Path.Combine(ufilename);
                    model.SelectList.CopyTo(new FileStream(filepath, FileMode.Create));
                }
                Medicine Medicinew = new Medicine
                {
                    Id = Convert.ToInt32(collection["Id"]),
                    Name = collection["Name"],
                    Description = collection["Description"],
                    Product = collection["Product"],
                    Price = Convert.ToInt32(collection["Price"]),
                    Existence = Convert.ToInt32(collection["Existence"])
                };
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AB/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AB/Edit/5
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

        // GET: AB/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AB/Delete/5
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
