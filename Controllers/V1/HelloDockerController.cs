using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Erudio.Data.DTO.V1;
using RestWithASPNET10Erudio.Services;

namespace RestWithASPNET10Erudio.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]/v1")]
    [Produces("application/json")]
    public class HelloDockerController : ControllerBase
    {
        private readonly IInstanceInformationService _instanceInformationService;
        private readonly ILogger<HelloDockerController> _logger;

        public HelloDockerController(
            IInstanceInformationService instanceInformationService,
            ILogger<HelloDockerController> logger)
        {
            _instanceInformationService = instanceInformationService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(InstanceInformationDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            var instanceInformation = _instanceInformationService.GetInstanceInformation();
            _logger.LogInformation(
                "Returning Hello Docker information for environment {environment} and instance {instanceId}",
                instanceInformation.Environment,
                instanceInformation.InstanceId);

            return Ok(instanceInformation);
        }
    }
}
