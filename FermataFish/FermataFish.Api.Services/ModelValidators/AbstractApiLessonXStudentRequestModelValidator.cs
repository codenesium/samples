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
	public abstract class AbstractApiLessonXStudentRequestModelValidator : AbstractValidator<ApiLessonXStudentRequestModel>
	{
		private int existingRecordId;

		private ILessonXStudentRepository lessonXStudentRepository;

		public AbstractApiLessonXStudentRequestModelValidator(ILessonXStudentRepository lessonXStudentRepository)
		{
			this.lessonXStudentRepository = lessonXStudentRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLessonXStudentRequestModel model, int id)
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

		public virtual void StudioIdRules()
		{
			this.RuleFor(x => x.StudioId).MustAsync(this.BeValidStudio).When(x => x?.StudioId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidLesson(int id,  CancellationToken cancellationToken)
		{
			var record = await this.lessonXStudentRepository.GetLesson(id);

			return record != null;
		}

		private async Task<bool> BeValidStudent(int id,  CancellationToken cancellationToken)
		{
			var record = await this.lessonXStudentRepository.GetStudent(id);

			return record != null;
		}

		private async Task<bool> BeValidStudio(int id,  CancellationToken cancellationToken)
		{
			var record = await this.lessonXStudentRepository.GetStudio(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>ceae37b7682527ac5db910d06f95807b</Hash>
</Codenesium>*/