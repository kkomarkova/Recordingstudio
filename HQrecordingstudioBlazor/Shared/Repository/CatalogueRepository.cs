using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using HQrecordingstudioBlazor.Shared.Models;
using HQrecordingstudioBlazor.Shared.Models.Configuration;

namespace HQrecordingstudioBlazor.Shared.Repository
{
    public class CatalogueRepository : ICatalogueRepository
    {
        private readonly DapperContext _context;
        public CatalogueRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<CatalogueItem>> GetCatalogue()
        {
            var query = "select * from Catalogue WHERE ParentId = 1";
            using (var connection = _context.CreateConnection())
            {
                return (await connection.QueryAsync<CatalogueItem>(query)).ToList();
                //return catalogueItems.ToList();
            }
        }

        // Get one catalogueitem based on its CatalogueItemID (SQL Select)
        public async Task<CatalogueItem> Catalogue_GetOne(int Id)
        {
            CatalogueItem catalogueItem = new CatalogueItem();
            using (var connection = _context.CreateConnection())
            {

                const string query = "spCatalogue_GetOne";
                var p = new DynamicParameters();
                p.Add(name: "@id", Id, DbType.Int32, ParameterDirection.Input);

                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                try
                {
                    //Get rid of new Id change it to p 
                    catalogueItem = await connection.QueryFirstOrDefaultAsync<CatalogueItem>(query, new { Id }, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
            return catalogueItem;
           
        }

        

        //public async Task<CatalogueItem> Catalogue_GetSamplePack(int ParentId)
        //{
        //    CatalogueItem catalogueSamplePack = new CatalogueItem();
        //    using (var connection = _context.CreateConnection())
        //    {

        //        const string query = "spCatalogue_GetSamplePack";
        //        var p = new DynamicParameters();
        //        p.Add(name: "@ParentId", ParentId, DbType.Int32, ParameterDirection.Input);

        //        if (connection.State == ConnectionState.Closed)
        //            connection.Open();
        //        try
        //        {
        //            catalogueSamplePack = await connection.QueryFirstOrDefaultAsync<CatalogueItem>(query, new { ParentId }, commandType: CommandType.StoredProcedure);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            if (connection.State == ConnectionState.Open)
        //                connection.Close();
        //        }
        //    }
        //    return catalogueSamplePack;
        //}
    }
}
