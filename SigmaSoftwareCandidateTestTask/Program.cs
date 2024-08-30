using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

 
builder.Services.AddControllers();
 builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICandidateRepository, CsvCandidateRepository>(provider =>
            new CsvCandidateRepository("C:\\Users\\Thinkpad_3\\Downloads\\generated_data.csv"));
builder.Services.AddScoped<ICandidateService, CandidateService>();
var app = builder.Build();
 
 if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
