using FitnessCore.Enums;
using FitnessCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessCore.Managers
{
    class ExerciseManager : IExerciseManager
    {
        private Dictionary<ExerciseType, double> CaloriesPerHourPerKilogram = new Dictionary<ExerciseType, double>()
        {
            { ExerciseType.Runing, 6.4},
            { ExerciseType.Skating, 3.2},
            { ExerciseType.Aerobics, 5.2},
            { ExerciseType.Cycing, 5.4},
            { ExerciseType.Gymnastics, 4},
            { ExerciseType.Streching, 1.8},
            { ExerciseType.Swiming, 6}
        };
        public double Exercise(ExerciseType type, double hours, double weight)
        {
            if (hours <= 0)
            {
                throw new ArgumentException("Invalid input: hours < 0.");
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Invalid input: weight < 0.");
            }
            return CaloriesPerHourPerKilogram.GetValueOrDefault(type) * hours * weight;
        }
    }
}
