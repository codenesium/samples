using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects

{
	public abstract class AbstractApiLessonXStudentRequestModelValidator: AbstractValidator<ApiLessonXStudentRequestModel>
	{
		public new ValidationResult Validate(ApiLessonXStudentRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiLessonXStudentRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ILessonRepository LessonRepository { get; set; }
		public IStudentRepository StudentRepository { get; set; }
		public virtual void LessonIdRules()
		{
			this.RuleFor(x => x.LessonId).NotNull();
			this.RuleFor(x => x.LessonId).MustAsync(this.BeValidLesson).When(x => x ?.LessonId != null).WithMessage("Invalid reference");
		}

		public virtual void StudentIdRules()
		{
			this.RuleFor(x => x.StudentId).NotNull();
			this.RuleFor(x => x.StudentId).MustAsync(this.BeValidStudent).When(x => x ?.StudentId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidLesson(int id,  CancellationToken cancellationToken)
		{
			var record = await this.LessonRepository.Get(id);

			return record != null;
		}

		private async Task<bool> BeValidStudent(int id,  CancellationToken cancellationToken)
		{
			var record = await this.StudentRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>4ce67e5e17c3bd641bdb14e493f74491</Hash>
</Codenesium>*/