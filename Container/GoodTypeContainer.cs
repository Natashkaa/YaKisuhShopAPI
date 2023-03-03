using YaKisuhShopApi.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
public class GoodTypeContainer : IGoodTypeContainer
{
    private readonly YaKisuhShopContext _dbContext;
    private readonly IMapper _mapper;
    public GoodTypeContainer (YaKisuhShopContext context, IMapper mapper){
        this._dbContext = context;
        this._mapper = mapper;
    } 
    public async Task<List<GoodTypeEntity>> GetAllTypes(){
        var typeData = await this._dbContext.GoodTypes.ToListAsync();
        if(typeData != null && typeData.Count > 0)
        {
            return this._mapper.Map<List<GoodType>, List<GoodTypeEntity>>(typeData);
        }
        else{
            return new List<GoodTypeEntity>();
        }
    }
}