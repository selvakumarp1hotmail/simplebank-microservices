using Microsoft.EntityFrameworkCore;
using SimpleBank.Transactions.Api.Persistence;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add Controllers
builder.Services.AddControllers();

// ✅ Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TransactionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Register Repository (Dependency Injection)
//builder.Services.AddSingleton<TransactionRepository>();
builder.Services.AddScoped<TransactionRepository>();

builder.Services.AddHttpClient(); // needed for Account API calls


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


var app = builder.Build();

app.UseCors("AllowReact");

// ✅ Middleware pipeline
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

// ✅ Map Controllers (VERY IMPORTANT)
app.MapControllers();

app.Run();