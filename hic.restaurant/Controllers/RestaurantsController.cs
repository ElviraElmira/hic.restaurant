using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hic.restaurant.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hic.restaurant.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly ITableRepository _tableRepository;

        public RestaurantsController(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_tableRepository.GetRestaurants());
        }

        [HttpGet("{name}")]
        public JsonResult Get(string name)
        {
            return new JsonResult(_tableRepository.GetRestaurant(name));
        }
    }
}