// using Example01._1.Models;

// namespace Example01
// {
//     class Program
//     {

//         static void Main(string[] args)
//         {
//             using (var context = new EmployeeContext())
//             {
//                 var std = new Employee()
//                 {
//                     FirstName = "thach",
//                     LastName = "nguyen",
//                     EmailId = "nguyentienthach23@gmail.com"

//                 };
//                 context.Employees.Add(std);
//                 context.SaveChanges();
//             }
//              using (var context = new EmployeeContext())
//             {
//                 var std = new Employee()
//                 {
//                     FirstName = "tuan",
//                     LastName = "nguyen",
//                     EmailId = "nguyentuan23@gmail.com"

//                 };
//                 context.Employees.Add(std);
//                 context.SaveChanges();

//                 Console.WriteLine("-----Loading all data ------");
//                 var Employees = context.Employees.ToList();
//                 foreach (var item in Employees)
//                 {
//                     Console.WriteLine(item.FirstName);
//                     Console.WriteLine(item.LastName);
//                     Console.WriteLine(item.EmailId);
//                 }
//                 Console.WriteLine("-----Loading a single entity ------");
//                 var employees = context.Employees.Single(e=>e.Id==1);           

//                     Console.WriteLine(employees.FirstName);
//                     Console.WriteLine(employees.LastName);
//                     Console.WriteLine(employees.EmailId);
//                 Console.WriteLine("-----Loading with Filtering ------");
//                 var employee = context.Employees.Where(b=>b.FirstName.Contains("thach")).ToList();
//                 foreach (var item in employee)
//                 {   
//                     Console.WriteLine(item.FirstName);
//                     Console.WriteLine(item.LastName);
//                     Console.WriteLine(item.EmailId);

//                 }

//             }
//         }
//     }
// }




using backend;
using backend.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// string mySqlConnectionStr = builder.Configuration.GetConnectionString("EmployeeConnectString");
string assemblyName = typeof(Example07Context).Namespace;

string Example07JSDomain = "_Example07JSDomain";
// builder.Services.AddDbContext<Example07Context>(options =>
// {
//     options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr), b => b.MigrationsAssembly(assemblyName));
// });

//Server=NGUYENHONGPHONG\\SQLEXPRESS;Database=Exampl05;User ID=sa;Password=sa;TrustServerCertificate=True
// Add services to the container.
 builder.Services.AddDbContext<Example07Context>(options =>{
     options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeConnectString"));
 });

builder.Services.AddCors(options =>{
options.AddPolicy(name:Example07JSDomain,policy=>policy.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader());

});
    



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAuthorizationBuilder();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(Example07JSDomain);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
