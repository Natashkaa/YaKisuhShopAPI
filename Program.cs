using YaKisuhShopApi.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
//
//var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
//

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<YaKisuhShopContext>(options =>{ 
    options.UseSqlServer(builder.Configuration.GetConnectionString("constring"));
});

builder.Services.AddCors();
builder.Services.AddMvc(opt => opt.EnableEndpointRouting = false);

builder.Services.AddTransient<IGoodContainer, GoodContainer>();
builder.Services.AddTransient<IGoodTypeContainer, GoodTypeContainer>();
builder.Services.AddTransient<IGoodImageContainer, GoodImageContainer>();
//mapper
var automapper = new MapperConfiguration(item => item.AddProfile(new MappingProfile()));
IMapper mapper = automapper.CreateMapper();
//
builder.Services.AddSingleton(mapper);
// .AddCors(options =>
// {
//     options.AddPolicy(name: MyAllowSpecificOrigins,
//                       policy  =>
//                       {
//                           policy.WithOrigins("http://localhost:3000")
//                           .AllowAnyHeader()
//                                                   .AllowAnyMethod();
//                       });
// });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
);
app.UseMvc();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
