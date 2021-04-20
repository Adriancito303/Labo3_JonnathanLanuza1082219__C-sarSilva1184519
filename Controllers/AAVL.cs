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
using Microsoft.VisualBasic.FileIO;

namespace Labo3_JonnathanLanuza1082219__CésarSilva1184519.Controllers
{
    public class AAVL : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        List<Medicine> Mclients = new List<Medicine>();
        //public AAVL(Medicine edf, IHostingEnvironment hostingEnvironment)
        //{
        //    medtouse = edf;
        //    this.hostingEnvironment = hostingEnvironment;
        //}
        // GET: AB
        public ActionResult Index()
        {
            return View(Singleton.Instance.MClientsList);
        }

        //[HttpPost]
        //public ActionResult Index(IFormFile postedFile)
        //{
        //    List<Medicine> customers = new List<Medicine>();
        //    string filePath = string.Empty;
        //    if (postedFile != null)
        //    {
        //        string path = Server.MapPath("~/Uploads/");
        //        if (!Directory.Exists(path))
        //        {
        //            Directory.CreateDirectory(path);
        //        }

        //        filePath = path + Path.GetFileName(postedFile.FileName);
        //        string extension = Path.GetExtension(postedFile.FileName);
        //        postedFile.SaveAs(filePath);

        //        //Read the contents of CSV file.
        //        string csvData = System.IO.File.ReadAllText(filePath);

        //        //Execute a loop over the rows.
        //        foreach (string row in csvData.Split('\n'))
        //        {
        //            if (!string.IsNullOrEmpty(row))
        //            {
        //                customers.Add(new Medicine
        //                {
        //                    Id = Convert.ToInt32(row.Split(',')[0]),
        //                    Name = row.Split(',')[1],
        //                    Description = row.Split(',')[2],
        //                    Product = row.Split(',')[3],
        //                    Price = Convert.ToInt32(row.Split(',')[4]),
        //                    Existence = Convert.ToInt32(row.Split(',')[5])
        //                });
        //            }
        //        }
        //    }

        //    return View(customers);
        //}

        //[HttpPost]
        //public ActionResult Create(MedicineModelsV model)
        //{
        //    string uniquefilename = null;
        //    if (ModelState.IsValid)
        //    {
        //        if (model.SelectList != null)
        //        {
        //            string uploadsfolder = Path.Combine(hostingEnvironment.WebRootPath, "Uploads");
        //            uniquefilename = Guid.NewGuid().ToString() + "_" + model.SelectList.FileName;
        //            string filepath = Path.Combine(uploadsfolder, uniquefilename);
        //            model.SelectList.CopyTo(new FileStream(filepath, FileMode.Create));
        //        }
                //Medicine newmed = new Medicine
                //{
                //    Id = model.Id,
                //    Name = model.Name,
                //    Description = model.Description,
                //    Product = model.Product,
                //    Price = model.Price,
                //    Existence = model.Existence,
                //    dock = uniquefilename
                //};
                //medtouse.Add(newmed);
            //}
            //var path = @"C:\MOCK_DATA(4).csv";
            //using (TextFieldParser csvParser = new TextFieldParser(path))
            //{
            //    csvParser.CommentTokens = new string[] { "#" };
            //    csvParser.SetDelimiters(new string[] { "," });
            //    csvParser.HasFieldsEnclosedInQuotes = true;

            //    csvParser.ReadLine();

            //    while (!csvParser.EndOfData)
            //    {
            //        string[] fields = csvParser.ReadFields();
            //        string Name = fields[0];
            //        string Address = fields[1];
            //    }
            //}
        //    return View();
        //}

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
        //[HttpPost]
        //public ActionResult Index(int Ex)
        //{
        //    ViewData["Resupply"] = Ex;
        //    Singleton.Instance.MClientsList.Clear();

        //    if (Ex == 0)
        //    {
        //        for (int i = 0; i < Singleton.Instance.MClientsList.Count() - 1; i++)
        //        {
        //            if (Singleton.Instance.MClientsList[i].Existence == Ex)
        //            {
        //                Singleton.Instance.MClientsList.Add(Singleton.Instance.MClientsList[i]);
        //                Medicine mednew = new Medicine();

        //                int? search = Convert.ToInt32(Mclients.Find(x => x.Existence == 0));
        //                if (search == 0)
        //                {
        //                    Random newex = new Random();
        //                    search = newex.Next(0, 15);
        //                }
        //            }
        //        }
        //        return View(Singleton.Instance.SecondMClientsList);
        //    }
        //    return View();
        //}

        public interface IFormFile
        {
            public int? Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Product { get; set; }
            public int Price { get; set; }
            public int? existence { get; set; }
            long Length { get; }
            string name { get; }
            string FileName { get; }
            Stream OpenReadStream();
            void CopyTo(Stream target);
            //Task CopyToAsync(Stream target, CancellationToken cancellationToken = null);
            //Task CopyToAsync(Stream target, CancellationToken cancellationToken = null);
        }

        // GET: AB/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AB/Create
        public ActionResult CreateClient()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateClient(IFormCollection collection)
        {
            return View("Index");
        }

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
                if (ModelState.IsValid)
                {
                    string uniquefilename = null;
                    if (model.SelectList != null)
                    {
                        string uploadsfolder = Path.Combine(hostingEnvironment.WebRootPath, "Uploads");
                        uniquefilename = Guid.NewGuid().ToString() + "_" + model.SelectList.FileName;
                        string filepath = Path.Combine(uploadsfolder, uniquefilename);
                        model.SelectList.CopyTo(new FileStream(filepath, FileMode.Create));
                    }
                    Medicine Medicinew = new Medicine
                    {
                        Id = Convert.ToInt32(collection["Id"]),
                        Name = collection["Name"],
                        Description = collection["Description"],
                        Product = collection["Product"],
                        Price = Convert.ToInt32(collection["Price"]),
                        Existence = Convert.ToInt32(collection["Existence"]),
                        //dock = uniquefilename
                    };
                    return RedirectToAction("Index", new { id = Medicinew.Id});
                }
                return View();
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
