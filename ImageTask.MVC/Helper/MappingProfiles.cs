using AutoMapper;
using ImageTask.Core.Entities;
using ImageTask.MVC.Models;

namespace ImageTask.MVC.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProductViewModel, Product>().ForMember(product => product.Image,
                o => o.MapFrom(productvm => DocumentSetting.ConvertImage(productvm.Image)));


        }
    }
}
