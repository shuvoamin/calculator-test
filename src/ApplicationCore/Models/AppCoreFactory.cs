﻿using ApplicationCore.Enums;
using ApplicationCore.Interfaces;
using System;

namespace ApplicationCore.Models
{
    public class AppCoreFactory
    {
        public static ICalculationResult CreateCalculatinoResult(double result)
        {
            ICalculationResult model = new CalculationResult()
            {
                Result = result
            };

            return model;
        }

        public static IProbabilityLogic CreateCalculationLogic(
            ProbabilityCalculationLogic calculationLogic
        )
        {
            IProbabilityLogic probabilityLogic = null;

            switch (calculationLogic)
            {
                case ProbabilityCalculationLogic.CombineWith:
                    probabilityLogic = new CombineWithProbabilityLogic();
                    break;
                case ProbabilityCalculationLogic.Either:
                    probabilityLogic = new EitherProbabilityLogic();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return probabilityLogic;
        }
    }
}