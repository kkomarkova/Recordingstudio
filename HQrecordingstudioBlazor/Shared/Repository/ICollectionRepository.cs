using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HQrecordingstudioBlazor.Shared.Models;

namespace HQrecordingstudioBlazor.Shared.Repository
{
    public interface ICollectionRepository
    {
        public Task<List<SamplePack>> Catalogue_GetSamplePack();
        public Task<List<SamplePack>> Catalogue_GetPackItems(int PackId);
    }
}
