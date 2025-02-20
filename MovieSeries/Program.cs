using FilmSeriesReview.Data;
using Microsoft.EntityFrameworkCore;
using Pj.DataAccessLayer.Repositories;
using Pj.RepositoryLayer.Interfaces;
using Pj.ServiceLayer.Interfaces;
using Pj.ServiceLayer.Services;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ Controllers
builder.Services.AddControllers();

// Cấu hình EF Core với SQL Server (chuỗi kết nối được định nghĩa trong appsettings.json)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Đăng ký Dependency Injection cho Repository và Service
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();

// Thêm Swagger (tùy chọn)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Cấu hình middleware (ví dụ: hiển thị lỗi chi tiết khi phát triển)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieReview API v1");
        c.RoutePrefix = "swagger";
    });
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
