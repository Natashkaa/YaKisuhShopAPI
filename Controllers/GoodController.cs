using Microsoft.AspNetCore.Mvc;

namespace YaKisuhShopApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GoodController : ControllerBase
{
    private readonly IGoodContainer container;

    public GoodController(IGoodContainer _container)
    {
        container = _container;
    }

    [HttpGet("GetAll")]
    public async Task<List<GoodEntity>> GetAll()
    {
        return await this.container.GetAllGoods();
    }

    [HttpGet("GetById/{id}")]
    public async Task<GoodEntity> GetById(int id)
    {
        var good = await this.container.GetOneGood(id);
        return good;
    }

    [HttpDelete("Delete/{id}")]
    public async Task<GoodEntity> Delete(int id)
    {
        var delGood = await this.container.Delete(id);
        return delGood;
    }

    [HttpPost("Create")]
    public async Task<GoodEntity> Create([FromBody] GoodEntity _newGood)
    {   
        await this.container.CreateUpdate(_newGood);
        return _newGood;
    }
}
