using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects

{
	public abstract class AbstractLessonXTeacherModelValidator: AbstractValidator<LessonXTeacherModel>
	{
		public new ValidationResult Validate(LessonXTeacherModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(LessonXTeacherModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ILessonRepository LessonRepository { get; set; }
		public IStudentRepository StudentRepository { get; set; }
		public virtual void LessonIdRules()
		{
			this.RuleFor(x => x.LessonId).NotNull();
			this.RuleFor(x => x.LessonId).Must(this.BeValidLesson).When(x => x ?.LessonId != null).WithMessage("Invalid reference");
		}

		public virtual void StudentIdRules()
		{
			this.RuleFor(x => x.StudentId).NotNull();
			this.RuleFor(x => x.StudentId).Must(this.BeValidStudent).When(x => x ?.StudentId != null).WithMessage("Invalid reference");
		}

		private bool BeValidLesson(int id)
		{
			return this.LessonRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidStudent(int id)
		{
			return this.StudentRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>c60e0264824877f2557accfe50632d40</Hash>
</Codenesium>*/