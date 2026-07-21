using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Api.Models;
using TaskManagement.Api.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// 向依賴注入系統登記：以後任何地方需要用到 AppDbContext 時，請照這個方式建立它——
// 去讀取 appsettings.json 裡叫做 DefaultConnection 的連線字串，用 PostgreSQL 驅動程式（Npgsql）連上去，
// 然後把設定好的 AppDbContext 交給需要它的地方（例如 TasksController）。
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
