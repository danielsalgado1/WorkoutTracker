using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkoutTracker.Dtos
{
    public class ExerciseDto
    {
        public int Id { get; set; }

        public string ExerciseName { get; set; } = "";

        public List<string> MuscleGroups { get; set; }
            = new List<string>();

        public string WeightType { get; set; } = "";
    }
}