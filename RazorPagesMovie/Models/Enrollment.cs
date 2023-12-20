﻿using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public enum Grade
    {
        A, B, C, D, E, F
    }
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudenId { get; set; }
        [DisplayFormat(NullDisplayText= "No grade")]
        public Grade? Grade { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
