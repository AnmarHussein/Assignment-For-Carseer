using Assignment_For_Carseer.Domain;
using Assignment_For_Carseer.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_For_Carseer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }


        [HttpGet("get-models/{modelYear}/{makeName}")]
        public async Task<Response<List<string>>> GetModels([FromRoute]int modelYear, [FromRoute] string makeName)
        {
            Response<List<string>> response = await _modelService.GetModels(modelYear, makeName);
            return response;    
        }
    }
}