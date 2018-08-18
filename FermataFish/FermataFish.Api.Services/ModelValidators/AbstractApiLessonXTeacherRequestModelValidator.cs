using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractApiLessonXTeacherRequestModelValidator : AbstractValidator<ApiLessonXTeacherRequestModel>
	{
		private int existingRecordId;

		private ILessonXTeacherRepository lessonXTeacherRepository;

		public AbstractApiLessonXTeacherRequestModelValidator(ILessonXTeacherRepository lessonXTeacherRepository)
		{
			this.lessonXTeacherRepository = lessonXTeacherRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLessonXTeacherRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void LessonIdRules()
		{
			this.RuleFor(x => x.LessonId).MustAsync(this.BeValidLesson).When(x => x?.LessonId != null).WithMessage("Invalid reference");
		}

		public virtual void StudentIdRules()
		{
			this.RuleFor(x => x.StudentId).MustAsync(this.BeValidStudent).When(x => x?.StudentId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidLesson(int id,  CancellationToken cancellationToken)
		{
			var record = await this.lessonXTeacherRepository.GetLesson(id);

			return record != null;
		}

		private async Task<bool> BeValidStudent(int id,  CancellationToken cancellationToken)
		{
			var record = await this.lessonXTeacherRepository.GetStudent(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>47d702eb97267e24b13b599332d35294</Hash>
</Codenesium>*/