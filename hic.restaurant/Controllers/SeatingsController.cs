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
    public class SeatingsController : ControllerBase
    {
        private readonly ITableRepository _tableRepository;

        public SeatingsController(ITableRepository tableRepository) {
            _tableRepository = tableRepository;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_tableRepository.GetAllAvailableTables());
        }
        
        [HttpGet("{name}")]
        public JsonResult Get(string name)
        {
            return new JsonResult(_tableRepository.GetTables(name));
        }

        [HttpPut("{id}")]
        public void Put(string id)
        {
            _tableRepository.BookTable(id);
        }
    }
}