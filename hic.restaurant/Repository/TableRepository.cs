using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hic.restaurant.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace hic.restaurant.Repository
{
    public class TableRepository : ITableRepository
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly string _filepath;

        public TableRepository(IHostingEnvironment hostingEnvironment) {
            _hostingEnvironment = hostingEnvironment;
            _filepath = "App_data/restaurant.json";
        }

        private string GetFilePath() {
            var contentRoot = _hostingEnvironment.ContentRootPath;
            return System.IO.Path.Combine(contentRoot, _filepath);
        }

        private string GetFile() {
            var filePath = GetFilePath();
            return System.IO.File.ReadAllText(filePath);
        }

        public List<Restaurant> GetRestaurants()
        {
            var jsonfile = GetFile();
            var list = JsonConvert.DeserializeObject<RestaurantList>(jsonfile);
            return list.Restaurants;
        }

        public Restaurant GetRestaurant(string restaurantname)
        {
            var restaurants = GetRestaurants();
            return restaurants.Where(r => r.Name.ToLower() == restaurantname.ToLower()).FirstOrDefault();
        }

        public List<Table> GetTables(string restaurantname)
        {
            Restaurant restaruant = GetRestaurant(restaurantname);
            List<Table> tableList = restaruant.Tables;
            return tableList;
        }

        public Table GetTable(string restaurantname, string id) {
            var tablelist = GetTables(restaurantname);
            return tablelist.Where(r => r.Id.ToLower() == id.ToLower()).FirstOrDefault();
        }

        public Table GetTable(string id)
        {
            var tablelist = GetAllTables();
            return tablelist.Where(r => r.Id.ToLower() == id.ToLower()).FirstOrDefault();
        }

        public List<Table> GetAllTables()
        {
            var restaurants = GetRestaurants();
            return restaurants.SelectMany(t => t.Tables).ToList();
        }

        public List<Table> GetAllAvailableTables()
        {
            var tables = GetAllTables();
            return tables.Where(o => o.IsAvailable && o.IsBookable).ToList();
        }
        
        public void BookTable(string tableid) {
            var filePath = GetFilePath();
            var file = GetFile();
            var restaurantsobject = JsonConvert.DeserializeObject<RestaurantList>(file);

            foreach (var r in restaurantsobject.Restaurants) {
                var table = r.Tables.Where(t => t.Id == tableid).FirstOrDefault();
                if (table == null) continue;
                if (table.IsAvailable && table.IsBookable) {
                    table.IsAvailable = false;
                }
            }
            string output = JsonConvert.SerializeObject(restaurantsobject, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, output);           
        }
    }
}
