using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects

{
	public abstract class AbstractApiLessonXTeacherModelValidator: AbstractValidator<ApiLessonXTeacherModel>
	{
		public new ValidationResult Validate(ApiLessonXTeacherModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiLessonXTeacherModel model)
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
			return this.LessonRepository.Get(id) != null;
		}

		private bool BeValidStudent(int id)
		{
			return this.StudentRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>02cf5caaa44e19ad38c69721c2bce34a</Hash>
</Codenesium>*/