using hic.restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hic.restaurant.Repository
{
    public interface ITableRepository
    {
        List<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(string restaurantname);
        List<Table> GetTables(string restaurantname);
        Table GetTable(string restaurantname, string id);
        List<Table> GetAllTables();
        List<Table> GetAllAvailableTables();
        void BookTable(string tableid);
    }
}
