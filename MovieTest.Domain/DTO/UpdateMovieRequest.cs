﻿using System;

using FluentValidation.Attributes;

using MovieTest.Domain.Validators;

namespace MovieTest.Domain.DTO
{
    [Validator(typeof(UpdateMovieRequestValidator))]
    public class UpdateMovieRequest
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Classification { get; set; }

        public string Duration { get; set; }

        public string Genres { get; set; }
    }
}