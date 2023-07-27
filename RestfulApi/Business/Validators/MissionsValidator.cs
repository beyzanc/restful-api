﻿using FluentValidation;
using Mission = RestfulApi.Models.Mission;

namespace RestfulApi.Business.Validators
{
    public class MissionsValidator : AbstractValidator<Mission>
    {
        public MissionsValidator()
        {
            RuleFor(t => t.Id)
                .NotEmpty().WithMessage("ID is required.")
                .GreaterThan(0).WithMessage("ID must be greater than 0.");

            RuleFor(t => t.Title)
                .NotEmpty().WithMessage("Please provide the title of the mission.")
                .MaximumLength(100).WithMessage("Title must be a maximum of 100 characters.");

            RuleFor(t => t.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(t => t.Deadline)
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Deadline must be today or a future date.");

            RuleFor(t => t.IsCompleted)
                .Must(x => x == true || x == false).WithMessage("This value must be either true or false.");

            RuleFor(t => t.Priority)
                .InclusiveBetween(1, 5).WithMessage("Please prioritize the mission with a number from 1 to 5.");

            RuleFor(t => t.Tags)
                .ForEach(tag => tag.MaximumLength(30).WithMessage("Each tag must not exceed 50 characters."));

        }
    }
}