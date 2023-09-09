using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test_Case_For_Programmer.Controllers
{
    public class MusicController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: Music
        public ActionResult Index()
        {
            var dataArtist = from x in dc.Artists select x;
            return View(dataArtist);
        }

        // GET: Music/Details/5
        public ActionResult Details(int id)
        {
            var detaiArtist = dc.Artists.Single(x => x.ArtistID==id);
            return View(detaiArtist);
        }

        // GET: Music/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Music/Create
        [HttpPost]
        public ActionResult Create(Artist collection)
        {
            try
            {
                dc.Artists.InsertOnSubmit(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Music/Edit/5
        public ActionResult Edit(int id)
        {
            var detaiArtist = dc.Artists.Single(x => x.ArtistID == id);
            return View(detaiArtist);
        }

        // POST: Music/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Artist collection)
        {
            try
            {
                Artist updateArtist = dc.Artists.Single(x => x.ArtistID == id);
                updateArtist.ArtistID = collection.ArtistID;
                updateArtist.ArtistName = collection.ArtistName;
                updateArtist.PackageName=collection.PackageName;
                updateArtist.ImageURL = collection.ImageURL;
                updateArtist.ReleaseDate = collection.ReleaseDate;  
                updateArtist.Price = collection.Price;
                updateArtist.SampleURL = collection.SampleURL;
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Music/Delete/5
        public ActionResult Delete(int id)
        {
            var detaiArtist = dc.Artists.Single(x => x.ArtistID == id);
            return View(detaiArtist);
        }

        // POST: Music/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var deleteArtist = dc.Artists.Single(x=>x.ArtistID == id);
                dc.Artists.DeleteOnSubmit(deleteArtist);
                dc.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
