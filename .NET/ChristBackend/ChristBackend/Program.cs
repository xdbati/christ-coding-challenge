using ChristBackend;

var builder = WebApplication.CreateBuilder(args);

const string FRONTEND_POLICY = "Frontend";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var allowedOrigins = builder.Configuration.GetValue<string>("AllowedOrigins")!.Split(",");
builder.Services.AddCors(options =>
{
    options.AddPolicy(FRONTEND_POLICY, policy =>
    {
        policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddSingleton<ArticleDataService>();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ArticleFetcherService>();
builder.Services.AddHostedService<ArticleSyncer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors(FRONTEND_POLICY);

app.UseAuthorization();

app.MapControllers();

app.Run();
