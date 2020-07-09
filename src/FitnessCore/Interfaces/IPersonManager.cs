using FitnessCore.Enums;
using FitnessCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessCore.Interfaces
{
    public interface IPersonManager
    {
        string CreateUser(string name, int age, double weight, double height);

        void DoExercise(Person person, ExerciseType type, double hours);
    }
}
