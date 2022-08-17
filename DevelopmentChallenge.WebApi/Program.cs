using AutoMapper;
using DevelopmentChallenge.CrossCutting;
using DevelopmentChallenge.CrossCutting.Mappings;

var builder = WebApplication.CreateBuilder(args);


# region Environment
Environment.SetEnvironmentVariable("Connection_db", builder.Configuration["ConnectionStrings:Connection_db"]);
#endregion

var configMapper = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityToViewProfile());

            });

IMapper mapper = configMapper.CreateMapper();
builder.Services.AddSingleton(mapper);

#region DI
ConfigureRepository.Config(builder.Services);
ConfigureService.Config(builder.Services);
#endregion
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
