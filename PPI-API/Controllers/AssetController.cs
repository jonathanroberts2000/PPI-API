namespace PPI_API.Controllers
{
    using System.Net;
    using PPI_Core.Services.Asset;
    using Microsoft.AspNetCore.Mvc;
    using PPI_API.AssetActions.GetAssets;
    using PPI_API.AssetActions.GetAssetTypes;
    using Microsoft.AspNetCore.Authorization;
    using Swashbuckle.AspNetCore.Annotations;

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AssetController : BaseController
    {
        private readonly IAssetService assetService;

        public AssetController(IAssetService assetService)
        {
            this.assetService = assetService;
        }

        [HttpGet]
        [SwaggerOperation("Método que se encarga de retornar todos los activos disponibles")]
        public IActionResult GetAssets()
        {
            GetAssetsResponse result = assetService.GetAssets();

            return CreateResponseHelper(result, HttpStatusCode.OK);
        }

        [HttpGet("types")]
        [SwaggerOperation("Método que se encarga de retornar todos los tipos de activos disponibles")]
        public IActionResult GetAssetTypes()
        {
            GetAssetTypesResponse result = assetService.GetAssetTypes();

            return CreateResponseHelper(result, HttpStatusCode.OK);
        }
    }
}