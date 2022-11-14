using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EFDemoWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PeopleContext _db;

        public IndexModel(ILogger<IndexModel> logger, PeopleContext db)
        {
            _db = db;
            _logger = logger;
        }

        public void OnGet()
        {
            LoadSampleData();

            //BAD EF query
            // It will download all data from People table, and filter it
            //var people = _db.People
            //    .Include(a => a.Addresses)
            //    .Include(a => a.EmailAddresses)
            //    .ToList()
            //    .Where(x => ApprovedAge(x.Age));  


            //It is a good EF query, because the "Where(x=> x.Age>=18 && x.Age<=65)" can be
            // transtlated into sql query so the filter will be in sql query then the filtered data 
            // will be downloaded. 
            var people = _db.People
                .Include(a => a.Addresses)
                .Include(a => a.EmailAddresses)
                .Where(x=> x.Age>=18 && x.Age<=65)
                .ToList();
        }


        private bool ApprovedAge(int age)
        {
            return (age >= 18 && age <= 65);
        }

        private void LoadSampleData()
        {
            if(_db.People.Count() == 0)
            {
                string file = System.IO.File.ReadAllText("generated.json");
                var people = JsonSerializer.Deserialize<List<Person>>(file);
                _db.AddRange(people);
                _db.SaveChanges();


            }
        }
    }
}
