using System;
using ApplicationCore.Enums;
using ApplicationCore.Interfaces;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        private readonly IAppLogger<CalculationsController> _logger;
        private readonly IProbabilityCalculationService _probabilityCalculationService;

        public CalculationsController(
            IAppLogger<CalculationsController> logger,
            IProbabilityCalculationService probabilityCalculationService
        )
        {
            _logger = logger;
            _probabilityCalculationService = probabilityCalculationService;
        }

        // GET api/calculations/0.5/0.5/1
        [HttpGet("{leftInput}/{rightInput}/{logicCode}")]
        public IActionResult Get(double leftInput, double rightInput, int logicCode)
        {
            string result = string.Empty;

            try
            {
                result = _probabilityCalculationService.GetCalculationResult(
                    leftInput,
                    rightInput,
                    (ProbabilityCalculationLogic) logicCode
                ).Result.ToString();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.StackTrace.ToString());

                return StatusCode(500);
            }

            return Ok(result);
        }
    }
}
