using AutoMapper;
using YaKisuhShopApi.Models;
public class MappingProfile:Profile{
    public MappingProfile(){
        CreateMap<Good, GoodEntity>();
        CreateMap<GoodEntity, Good>();
        CreateMap<GoodType, GoodTypeEntity>();
        CreateMap<GoodTypeEntity, GoodType>();
        CreateMap<GoodImage, GoodImageEntity>();
        CreateMap<GoodImageEntity, GoodImage>();
    }

}