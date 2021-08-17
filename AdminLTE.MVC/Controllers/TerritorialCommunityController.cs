using AdminLTE.MVC.Data;
using Microsoft.AspNetCore.Mvc;
using AdminLTE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.Controllers
{
    public class TerritorialCommunityController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TerritorialCommunityController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<TerritorialCommunity> tcList = _db.TerritorialCommunities;
            return View(tcList);
        }
        public IActionResult Upsert(int? id)
        {
            TerritorialCommunity tc = new TerritorialCommunity();

            if (id == null)
            {
                return View(tc);
            }
            else
            {
                tc = _db.TerritorialCommunities.Find(id);
                if (tc == null)
                {
                    return NotFound();
                }
                return View(tc);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(TerritorialCommunity tc)
        {

            if (ModelState.IsValid)
            {
                if (tc.Id == 0)
                    _db.TerritorialCommunities.Add(tc);

                else
                    _db.TerritorialCommunities.Update(tc);


                _db.SaveChanges();
            
                return RedirectToAction("Index");
            }
            return View(tc);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            TerritorialCommunity tc = _db.TerritorialCommunities.FirstOrDefault(u => u.Id == id);
            if (tc == null)
            {
                return NotFound();
            }

            return View(tc);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var tc = _db.TerritorialCommunities.Find(id);
            if (tc == null)
            {
                return NotFound();
            }

            _db.TerritorialCommunities.Remove(tc);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }

    }
}
