using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ASPNET.dro;
using ASPNET.dto;
using ASPNET.Models;
using ASPNET.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace ASPNET.Controllers
{
    [ApiController]
    [Route("api/item")]
    public class itemController : ControllerBase
    {
        Mock mock = new Mock();

        private readonly IRepo repo;
        private readonly IMapper mapper;

        public itemController(IRepo _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }

        [HttpGet]
        public ActionResult GetAllItems()
        {
            var items = repo.GetAllItems();
            foreach(Item item in items)
            {
                Console.WriteLine("item.id: " + item.Id);
            }
            return Ok(mapper.Map<IEnumerable<ItemReadDto>>(repo.GetAllItems()));
        }

        [HttpGet("{id}", Name ="GetItemById")]       //sub route
        public ActionResult GetItemById(int id)
        {
            
            return Ok(mapper.Map<Item>(repo.GetItemById(id)));
        }


        [HttpPost]
        public IActionResult CreateItem(itemWriteDto i)
        {
            var item = mapper.Map<Item>(i);

            repo.AddItem(item);
            repo.SaveChanges();

            return CreatedAtRoute(nameof(GetItemById), new {Id = item.Id}, item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, ItemUpdateDto i)
        {
            var bestaandItem = repo.GetItemById(id);
            if(bestaandItem == null)
            {
                return NotFound();
            }
            
            mapper.Map(i, bestaandItem);

            repo.UpdateItem(bestaandItem);

            repo.SaveChanges();

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var bestaandItem = repo.GetItemById(id);
            if(bestaandItem == null)
            {
                return NotFound();
            }


            repo.DeleteItem(bestaandItem);
            repo.SaveChanges();

            return Ok();
        }


    }
}