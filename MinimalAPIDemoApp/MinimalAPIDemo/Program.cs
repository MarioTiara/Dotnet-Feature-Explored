using System.Text;
using DataAccess.DbAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MinimalAPIDemo;
using MinimalAPIDemo.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IUserData, UserData>();
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

builder.Services.AddAuthentication(options=>{
    options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme=JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(jwt=>{
        var key= Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig:secret").Value);
        jwt.SaveToken=true;
        jwt.TokenValidationParameters= new TokenValidationParameters(){
            ValidateIssuerSigningKey=true,
            IssuerSigningKey=new SymmetricSecurityKey(key),
            ValidateIssuer=false, //for dev
            ValidateAudience=false, //for dev
            RequireExpirationTime=false, //for dev 
            ValidateLifetime=true,
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
//app.UseAuthorization();
app.ConfigureApi();

app.Run();
