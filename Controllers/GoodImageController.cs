using Microsoft.AspNetCore.Mvc;

namespace YaKisuhShopApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GoodImageController : ControllerBase
{
    private readonly IGoodImageContainer container;

    public GoodImageController(IGoodImageContainer _container)
    {
        container = _container;
    }

    [HttpGet("GetAll")]
    public async Task<List<GoodImageEntity>> GetAll()
    {
        return await this.container.GetAllImages();
    }
}
