using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PRO401;
using PRO401.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO401Test
{
    public class BaseTest
    {
        protected ApplicationDbContext BuildDatabaseContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            var dbContext = new ApplicationDbContext(options);

            return dbContext;
        }

        protected IMapper BuildMapper()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new Profiles()));
            var mapper = new Mapper(configuration);
            return mapper;
        }
    }
}
