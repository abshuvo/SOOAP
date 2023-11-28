using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoapCore;
//using SoapCore;
using SoapTrail.Data;
using SoapTrail.Services;
using System.ServiceModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();//a

builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddMvc();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
//app.UseSoapEndpoint<IProductService>("/ProductService.asmx", new SoapEncoderOptions(), SoapSerializer.DataContractSerializer);
//app.UseSoapEndpoint<IProductService>("/ProductService.asmx", new BasicHttpBinding(), SoapSerializer.XmlSerializer);
/*app.UseEndpoints(endpoints => {
    endpoints.UseSoapEndpoint<IProductService>("/ProductService.asmx", new SoapEncoderOptions(), SoapSerializer.DataContractSerializer);
});*/
app.UseRouting();
app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
    endpoints.UseSoapEndpoint<IProductService>("/ProductService.asmx", new SoapEncoderOptions(), SoapSerializer.DataContractSerializer);
}); 
app.Run();
