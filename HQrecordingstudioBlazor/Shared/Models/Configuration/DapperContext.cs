using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace HQrecordingstudioBlazor.Shared.Models.Configuration
{
    public class DapperContext
    {
        //We inject the IConfiguration interface to enable access to the connection string from our appsettings.json file. Also, we create the CreateConnection method, which returns a new SQLConnection object. 
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
