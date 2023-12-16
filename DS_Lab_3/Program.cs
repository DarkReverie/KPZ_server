using DS_Lab_3;
using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;
using DS_Lab_3.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new() { Title = "GymSystem", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT Token with Bearer into field"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference() {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("EmployeeOnly", policy => policy.RequireRole("employee"));
    options.AddPolicy("MembershipOnly", policy => policy.RequireRole("membership"));
    options.AddPolicy("MembershipAndEmployee", policy => policy.RequireRole("membership", "employee"));
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthenticationOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthenticationOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthenticationOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    });
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IBathhousereservationService, BathhousereservationService>();
builder.Services.AddScoped<IBoughtshopitemService, BoughtshopitemService>();
builder.Services.AddScoped<IEmployeeRoleService, EmployeeRoleService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<ILockerassignmentService, LockerassignmentService>();
builder.Services.AddScoped<ILockerService, LockerService>();
builder.Services.AddScoped<IMembershipService, MembershipService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IShopitemService, ShopitemService>();                
builder.Services.AddScoped<ITrainersessionService, TrainersessionService>();
builder.Services.AddScoped<IWorkoutclassService, WorkoutclassService>();

builder.Services.AddDbContext<GymDsCopyContext>(options => {
    options.UseLazyLoadingProxies(true);
});

var app = builder.Build();
app.UseCors(builder =>
{
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader().WithMethods("PUT"); ;
});

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowAnyOrigin");
}
app.MapControllers();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
// app.MapGet("/", () => "Hello World!");

app.Run();