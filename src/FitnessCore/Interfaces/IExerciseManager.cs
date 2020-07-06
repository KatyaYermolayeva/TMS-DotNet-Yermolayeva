using FitnessCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessCore.Interfaces
{
    public interface IExerciseManager
    {
        double Exercise(ExerciseType type, double minutes, double weight);
    }
}
