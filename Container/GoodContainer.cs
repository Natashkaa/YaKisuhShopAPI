using YaKisuhShopApi.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

public class GoodContainer : IGoodContainer {
    private readonly YaKisuhShopContext _dbContext;
    private readonly IMapper mapper;
    public GoodContainer(YaKisuhShopContext context, IMapper _mapper){
        this._dbContext = context;
        this.mapper = _mapper;
    }
    public async Task<List<GoodEntity>> GetAllGoods(){
        var goodData = await this._dbContext.Goods.Where(x => x.IsOnSale == true).ToListAsync();
        if(goodData != null && goodData.Count > 0){
            return this.mapper.Map<List<Good>, List<GoodEntity>>(goodData);
        }
        return new List<GoodEntity>();
    }
    public async Task<GoodEntity> GetOneGood(int id){
        var good = await this._dbContext.Goods.FirstOrDefaultAsync(g => g.GoodId == id);
        if(good != null){
            return this.mapper.Map<Good, GoodEntity>(good);
        }
        return new GoodEntity();
    }
    public async Task<GoodEntity> Delete(int id){
        var good = await OneGood(id);
        if(good != null){
            this._dbContext.Remove(good);
            await this._dbContext.SaveChangesAsync();
            return this.mapper.Map<Good, GoodEntity>(good);
        }
        return new GoodEntity();
    }
    public async Task<GoodEntity> CreateUpdate(GoodEntity newGood){
        var good = await OneGood(newGood.GoodId);
        Console.WriteLine($"GOOD ID {good}");
        if(good != null){
            //update
            good.GoodName = newGood.GoodName;
            good.GoodPrice = newGood.GoodPrice;
            good.GoodType = newGood.GoodType;
            good.GoodDescription = newGood.GoodDescription;
            Console.WriteLine("GOOD" + good);
            this._dbContext.Update(good);
            await this._dbContext.SaveChangesAsync();
            return this.mapper.Map<Good,GoodEntity>(good);
        }
        else{
            //new
            await this._dbContext.AddAsync(this.mapper.Map<GoodEntity, Good>(newGood));
            await this._dbContext.SaveChangesAsync();
            return newGood;
        }
    }
    //helping methods
    private async Task<Good> OneGood(int id){
        return await this._dbContext.Goods.FirstOrDefaultAsync(g => g.GoodId == id);
    }
}