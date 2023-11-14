using AutoMapper;
using ImageTask.API.Dtos;
using ImageTask.Core.Entities;
using ImageTask.MVC.Helper;

namespace ImageTask.API.Helper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {

            CreateMap<ProductDto, Product>().ForMember(product => product.Image,
                o => o.MapFrom(productdto => DocumentSetting.ConvertImage(productdto.Image)));
        }
    }
}
