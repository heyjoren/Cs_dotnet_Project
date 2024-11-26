using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET.dro;
using ASPNET.dto;
using ASPNET.Models;
using AutoMapper;

namespace ASPNET.Mappings
{
    public class ItemProfile : Profile
    {
        
        public ItemProfile()
        {
            CreateMap<Item, ItemReadDto>();         //read
            CreateMap<itemWriteDto, Item>();        //write
            CreateMap<ItemUpdateDto, Item>();        //update

        }

    }
}