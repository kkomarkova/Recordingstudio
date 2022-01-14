using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HQrecordingstudioBlazor.Shared.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HQrecordingstudioBlazor.Server.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionRepository _collectionRepo;
        public CollectionController(ICollectionRepository collectionRepo)
        {
            _collectionRepo = collectionRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Catalogue_GetSamplePack()
        {
            try
            {
                var catalogueSamplePack = await _collectionRepo.Catalogue_GetSamplePack();
                return Ok(catalogueSamplePack);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }

        }
    }
}
