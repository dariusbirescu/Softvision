using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CityFilterController : Controller
    {
        // GET: CityFilter
        public ActionResult Index(CityFilterViewModel vm)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            IQueryable<City> query = db.Cities;
            if (vm.Name != null)
            {
                query = query.Where(u => u.ApplicationUser.UserName.Contains(vm.Name));
                
            }
            if (vm.Email != null)
            {
                query = query.Where(u => u.ApplicationUser.Email.Contains(vm.Email));
            }
            if (vm.MaxTroupCount != null)
            {
                query = query.Where(c => c.Troups.Sum(t=> t.TroupCount)<vm.MaxTroupCount);
            }
            if (vm.MinTroupCount != null)
            {
                query = query.Where(c => c.Troups.Sum(t => t.TroupCount) > vm.MinTroupCount);
            }

            vm.Results = query.ToList();
            return View(vm);
        }
    }

    
}