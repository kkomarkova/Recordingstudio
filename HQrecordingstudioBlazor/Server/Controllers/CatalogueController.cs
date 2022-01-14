using HQrecordingstudioBlazor.Shared.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HQrecordingstudioBlazor.Server.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogueController : ControllerBase
    {
        private readonly ICatalogueRepository _catalogueRepo;

        public CatalogueController(ICatalogueRepository catalogueRepo)
        {
            _catalogueRepo = catalogueRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCatalogue()
        {
            try
            {
                var catalogueItems = await _catalogueRepo.GetCatalogue();
                return Ok(catalogueItems);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Catalogue_GetOne(int Id)
        {
            var catalogueItem = await _catalogueRepo.Catalogue_GetOne(Id);

            if (catalogueItem == null)
            {
                return NotFound($"Account with Id {Id} doesn't exit");
            }

            return Ok(catalogueItem);
        }

    }
}
    
