using System.Linq;
using AutoMapper;
using PosAPI.Dtos;
using PosAPI.Models;

namespace PosAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Supplier, SupplierDto>().ReverseMap();
            CreateMap<Devision, DevisionDto>().ReverseMap();
        }
    }
}