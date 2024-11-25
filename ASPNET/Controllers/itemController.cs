using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET.Models;
using ASPNET.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET.Controllers
{
    [ApiController]
    [Route("api/item")]
    public class itemController : ControllerBase
    {
        Mock mock = new Mock();

        [HttpGet]
        public ActionResult GetAllItems()
        {
            return Ok(mock.GetAllItems());
        }

        [HttpGet("{id}")]       //sub route
        public ActionResult GetItemById(int id)
        {
            
            return Ok(mock.GetItemById(id));
        }


    }
}