using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HQrecordingstudioBlazor.Shared.Models;

namespace HQrecordingstudioBlazor.Shared.Repository
{
    public interface ICatalogueRepository
    {
        public Task<List<CatalogueItem>> GetCatalogue();
        public Task<CatalogueItem> Catalogue_GetOne(int Id);

    }
}
