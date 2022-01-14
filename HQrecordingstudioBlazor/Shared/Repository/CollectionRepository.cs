using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using HQrecordingstudioBlazor.Shared.Models;
using HQrecordingstudioBlazor.Shared.Models.Configuration;

namespace HQrecordingstudioBlazor.Shared.Repository
{
    public class CollectionRepository : ICollectionRepository
    {
        private readonly DapperContext _context;
        public CollectionRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<SamplePack>> Catalogue_GetSamplePack()
        {
            var querysample = "SELECT * FROM Catalogue WHERE ParentId IS NULL";
            using (var connection = _context.CreateConnection())
            {
                return (await connection.QueryAsync<SamplePack>(querysample)).ToList();
                //return catalogueItems.ToList();
            }
        }
    }
}
