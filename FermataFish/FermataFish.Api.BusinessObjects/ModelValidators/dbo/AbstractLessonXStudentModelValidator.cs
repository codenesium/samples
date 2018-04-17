using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects

{
	public abstract class AbstractLessonXStudentModelValidator: AbstractValidator<LessonXStudentModel>
	{
		public new ValidationResult Validate(LessonXStudentModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(LessonXStudentModel model)
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
    <Hash>0daf5246d44c25b81a4cb58a8807c223</Hash>
</Codenesium>*/