using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RetailDiscount.Business.Abstract;
using RetailDiscount.Business.Concrete;
using RetailDiscount.DataAccess.Abstract;
using RetailDiscount.DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<ICustomerDal, EFCustomerDal>();

builder.Services.AddScoped<IInvoiceService, InvoiceManager>();
builder.Services.AddScoped<IInvoiceDal, EFInvoiceDal>();

builder.Services.AddScoped<IInvoiceDiscountService,InvoiceDiscountManager>();
builder.Services.AddScoped<IInvoiceDiscountDal, EFInvoiceDiscountDal>();

builder.Services.AddScoped<IInvoiceLineService, InvoiceLineManager>();
builder.Services.AddScoped<IInvoiceLineDal, EFInvoiceLineDal>();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EFProductDal>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
