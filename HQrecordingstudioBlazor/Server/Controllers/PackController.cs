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
    public class PackController : ControllerBase
    {
        private readonly ICollectionRepository _collectionRepo;
        public PackController(ICollectionRepository collectionRepo)
        {
            _collectionRepo = collectionRepo;
        }

     
        [HttpGet("{PackId}")]
        public async Task<IActionResult> Catalogue_GetPackItems(int PackId)
        {
            var catalogueItem = await _collectionRepo.Catalogue_GetPackItems(PackId);

            if (catalogueItem == null)
            {
                return NotFound($"Account with Id {PackId} doesn't exit");
            }

            return Ok(catalogueItem);
        }

    }
    
}
