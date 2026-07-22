//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace NotBook.Repository.Data
//{
//    public class AppDbContextFactory: IDesignTimeDbContextFactory<AppDbContext>
//    {
//        public AppDbContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
//            optionsBuilder.UseSqlServer("Server=.;Database=NotBookDb;Trusted_Connection=True;");
//            return new AppDbContext(optionsBuilder.Options);
//        }
//    }
//}
