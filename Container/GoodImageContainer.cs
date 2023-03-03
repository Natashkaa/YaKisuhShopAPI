using YaKisuhShopApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
    public class GoodImageContainer : IGoodImageContainer
    {
        private readonly YaKisuhShopContext context;
        private readonly IMapper mapper;
        public GoodImageContainer(IMapper _mapper, YaKisuhShopContext _context){
            this.context = _context;
            this.mapper = _mapper;
        }
        public async Task<List<GoodImageEntity>> GetAllImages(){
            var images = await this.context.GoodImages.ToListAsync();
            if(images != null && images.Count > 0){
                return this.mapper.Map<List<GoodImage>, List<GoodImageEntity>>(images);
            }
            return new List<GoodImageEntity>();
        }
    }