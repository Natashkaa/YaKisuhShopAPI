using Microsoft.AspNetCore.Mvc;

namespace YaKisuhShopApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GoodTypeController : ControllerBase
{
    private IGoodTypeContainer _container;
    public GoodTypeController(IGoodTypeContainer container)
    {
        this._container = container;
    }
    [HttpGet("GetAll")]
    public async Task<List<GoodTypeEntity>> GetAll()
    {
        return await this._container.GetAllTypes();
    }
}