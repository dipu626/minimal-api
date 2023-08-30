using MagicVilla_CouponAPI.Data;
using MagicVilla_CouponAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/coupon", () =>
{
    return Results.Ok(CouponStore.coupons.ToList());
});

app.MapGet("/api/coupon/{id:int}", (int id) =>
{
    Coupon coupon = CouponStore.coupons.FirstOrDefault(x => x.Id == id);
    if (coupon is not null)
    {
        return Results.Ok(coupon);
    }
    return Results.NotFound($"Coupon with id = {id} not found.");
});

app.MapPost("/api/coupon", () =>
{

});

app.MapPut("/api/coupon", () =>
{

});

app.MapDelete("/api/coupon/{id:int}", (int id) =>
{
    Coupon coupon = CouponStore.coupons.FirstOrDefault(x => x.Id == id);
    if (coupon is not null)
    {
        CouponStore.coupons.Remove(coupon);
    }
    return Results.NotFound($"Coupon with id = {id} not found.");
});

app.UseHttpsRedirection();

app.Run();
