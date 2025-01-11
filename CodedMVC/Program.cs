using CodedMVC.Data;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();
//Declare SQL service by entity framework core
builder.Services.AddDbContext<CodedDbContext>(options => 
{//add db context codeddbcontext
 //take object optiond. sqlserver needs creditntials okay sure go to configeration file. which will directly go to appsetting then say okay name of con is
 //con1 if not found it will error
 //sql or what type of sql //parent class //connectionstring
    options.UseSqlServer
    (builder.Configuration.
    GetConnectionString("con1"));
   // before they write  this instead they now write con1 :  GetConnectionString(Server = (localdb)\\MSSQLLocalDB; Database = CodedMVCDB; Trusted_Connection = True; MultipleActiveResultSets = true
    //con1 connects like a sim card its the name of a connection like zain viva whatever
});



var app = builder.Build();
//pipeline  checks if allows to enter
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
