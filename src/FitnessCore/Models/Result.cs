using FitnessCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessCore.Models
{
    public class Result
    {
        public DateTime Date { get; set; }

        public ExerciseType Type { get; set; }

        public double Calories { get; set; }
    }
}
