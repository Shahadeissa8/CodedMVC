using CodedMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CodedMVC.Data
{
    public class CodedDbContext : DbContext
    {
        //Constructor
        public CodedDbContext(DbContextOptions<CodedDbContext>options): base(options)
        //here options contains whats inside program its an object that holds that in instead of writing it all i took an object
        //then in options there i took all the data from appsettings so that i dont copy it all here
        //this line is to put options inside codeddbcontext that will put it all to dbcontext the built in
        //if we add a class here we dont need to repeat this line
        //this line is a constructor inject: 
        //options is like a rope conecceted to program if not the same name in db then wont connect 
        {

        }
        //entity
        public DbSet<Employee> Employees { get; set; } //employees for objext //Employees for class
        public DbSet<Student> Students { get; set; }

    }//after doing all this go to tools nuget first option write add-mig then tab then name of the file whatever 
     //it is at first but then start writing ur updates not random 
     //new qyery select * from delete from where dont write that in sql 

}
