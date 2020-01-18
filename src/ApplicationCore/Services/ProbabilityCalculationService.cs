﻿using ApplicationCore.Enums;
using System;
using ApplicationCore.Models;
using ApplicationCore.Interfaces;
using Infrastructure.Interfaces;

namespace ApplicationCore.Services
{
    public class ProbabilityCalculationService : IProbabilityCalculationService
    {
        private readonly IAppLogger<IProbabilityCalculationService> _logger;
        private const string c_ResultLogginMessage = "Logging Probability Calculation : ";
        private const string c_InvalidInputErrMsg = "input values are not valid";

        public ProbabilityCalculationService(IAppLogger<IProbabilityCalculationService> logger)
        {
            _logger = logger;
        }

        public ICalculationResult GetCalculationResult(
            double leftInput, 
            double rightInput, 
            ProbabilityCalculationLogic calculationLogic
        )
        {
            if (!IsInputsValidForProbabilityCalculation(leftInput, rightInput))
                throw new InvalidOperationException(c_InvalidInputErrMsg);

            if (calculationLogic == default(ProbabilityCalculationLogic))
                throw new InvalidOperationException(nameof(calculationLogic));

            ICalculationResult result = null;
            IProbabilityLogic probabilityLogic = 
                AppCoreFactory.CreateCalculationLogic(calculationLogic);

            if (probabilityLogic != null)
            {
                result = AppCoreFactory.CreateCalculatinoResult(
                    // using Decorator Pattern
                    probabilityLogic.GetCalculationResult(leftInput, rightInput)
                );

                // TODO : tidy up a little bit more
                // for testability purpose we need to add the whole logging object
                // as part of ICalculationResult
                _logger.LogInformation(
                    $"{c_ResultLogginMessage} " +
                    $"timeStamp = {DateTime.Now}, " +
                    $"leftInput = {leftInput}, " +
                    $"rightInput = {rightInput}, " +
                    $"calculationLogic = {calculationLogic.ToString()}, " +
                    $"result = {result.Result}"
                 );
            }

            return result;
        }

        private bool IsInputsValidForProbabilityCalculation(double leftInput, double rightInput)
        {
            bool isNumberValid(double value) =>
                !(value < 0)
                && (value % 0.5 == 0
                || value == 0);

            bool isValid = (leftInput + rightInput) != 0
                           && isNumberValid(leftInput)
                           && isNumberValid(rightInput);

            return isValid;
        }
    }
}