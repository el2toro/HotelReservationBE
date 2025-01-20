using HotelReservation.Contexts;
using HotelReservation.RabbitMQ;
using HotelReservation.Repository;
using HotelReservation.Services;
using HotelReservation.Stripe;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Stripe;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HotelReservationContext>();
builder.Services.AddControllers();

// Add dependancies
builder.Services.AddScoped<IHotelReservationRepository, HotelReservationRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IRabbitMQService, RabbitMQService>();

builder.Services.AddSingleton<ITwilioService, TwilioService>();
builder.Services.AddSingleton<IEmailSendService, EmailSendService>();
builder.Services.AddSingleton<IRabbitMQConsumer, RabbitMQConsumer>();

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(builder =>
        builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()));

//Jwt configuration
var jwtKey = builder.Configuration.GetSection("Jwt.Key").Get<string>();
var jwtIssuer = builder.Configuration.GetSection("Jwt.Issuer").Get<string>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "theissuer.com",
            ValidAudience = "theissuer.com",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mySecureKey55649"))
        };
    });

builder.Services.AddAuthentication();

// Stripe configuration
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

var app = builder.Build();

var rabbitMqConsumer = app.Services.GetService<IRabbitMQConsumer>();
await Task.Run(() => rabbitMqConsumer.StartConsuming());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

