using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WorkoutTracker.Dtos;
using WorkoutTracker.Models;

namespace WorkoutTracker.Controllers
{
    [RoutePrefix("api/exercises")]
    public class ExercisesController : ApiController
    {
        private static readonly List<WeightedExercise> exercises =
            new List<WeightedExercise>
            {
                new WeightedExercise
                {
                    Id = 1,
                    ExerciseName = "Bench Press",
                    MuscleGroups = new List<string>
                    {
                        "Chest", "Triceps", "Shoulders"
                    },
                    WeightType = "Barbell"
                },
                new WeightedExercise
                {
                    Id = 2,
                    ExerciseName = "Bicep Curl",
                    MuscleGroups = new List<string>
                    {
                        "Biceps"
                    },
                    WeightType = "Dumbbell"
                }
            };

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            List<ExerciseDto> results = exercises
                .Select(exercise => ToDto(exercise))
                .ToList();

            return Json(results);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            WeightedExercise exercise = exercises.FirstOrDefault(item => item.Id == id);

            if (exercise == null)
            {
                return NotFound();
            }

            return Json(ToDto(exercise));
        }

        private static ExerciseDto ToDto(WeightedExercise exercise)
        {
            return new ExerciseDto
            {
                Id = exercise.Id,
                ExerciseName = exercise.ExerciseName,
                MuscleGroups = new List<string>(exercise.MuscleGroups),
                WeightType = exercise.WeightType
            };
        }
    }
}