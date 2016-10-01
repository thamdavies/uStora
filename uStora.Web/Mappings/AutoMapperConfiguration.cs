using AutoMapper;
using uStora.Model.Models;
using uStora.Web.Models;

namespace uStora.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            //Post
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<PostCategory, PostCategoryViewModel>();
            Mapper.CreateMap<PostTag, PostTagViewModel>();
            //tag
            Mapper.CreateMap<Tag, TagViewModel>();
            //Product
            Mapper.CreateMap<ProductCategory, ProductCategoryViewModel>();
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<ProductTag, ProductTagViewModel>();
            //slide
            Mapper.CreateMap<Slide, SlideViewModel>();
            //contactdetail
            Mapper.CreateMap<ContactDetail, ContactDetailViewModel>();
            //feedback
            Mapper.CreateMap<Feedback, FeedbackViewModel>();
            //footer
            Mapper.CreateMap<Footer, FooterViewModel>();
        }
    }
}