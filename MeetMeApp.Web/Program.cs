using MeetMeApp.Web.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();

// Add DbContext with SQL Server configuration
builder.Services.AddDbContext<MeetMeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MeetingAppDbConnectionString")));

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. 
    app.UseHsts();
}

//app.UseDeveloperExceptionPage();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages(); // This should map your Razor Pages correctly
    

// Run the application
app.Run();
