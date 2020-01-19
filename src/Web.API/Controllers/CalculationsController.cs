using System;
using ApplicationCore.Enums;
using ApplicationCore.Interfaces;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Calculates a probability.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        /// /api/calculations/0.5/0.5/1
        ///
        /// </remarks>
        /// <param name="leftInput">Value for P(A)</param>
        /// <param name="rightInput">Value for P(B)</param>
        /// <param name="logicCode">Value for which probability logic to use</param>
        /// <returns>Probability calculation result</returns>
        /// <response code="200">Returns succesfull calculation result</response>
        /// <response code="500">If any validation or system exception occurs</response> 
        [HttpGet("{leftInput}/{rightInput}/{logicCode}")]
        public IActionResult Get(double leftInput, double rightInput, int logicCode)
        {
            string result = string.Empty;

            try
            {
                result = _probabilityCalculationService.GetCalculationResult(
                    leftInput,
                    rightInput,
                    logicCode
                ).Result.ToString();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(
                    ex.StackTrace.ToString(),
                    leftInput,
                    rightInput,
                    logicCode
                );

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(new { calculationResult = result });
        }
    }
}
