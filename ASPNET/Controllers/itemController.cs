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

        private readonly IRepo repo;

        public itemController(IRepo _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public ActionResult GetAllItems()
        {
            return Ok(repo.GetAllItems());
        }

        [HttpGet("{id}")]       //sub route
        public ActionResult GetItemById(int id)
        {
            
            return Ok(repo.GetItemById(id));
        }


    }
}