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
	public abstract class AbstractApiLessonRequestModelValidator : AbstractValidator<ApiLessonRequestModel>
	{
		private int existingRecordId;

		private ILessonRepository lessonRepository;

		public AbstractApiLessonRequestModelValidator(ILessonRepository lessonRepository)
		{
			this.lessonRepository = lessonRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLessonRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ActualEndDateRules()
		{
		}

		public virtual void ActualStartDateRules()
		{
		}

		public virtual void BillAmountRules()
		{
		}

		public virtual void LessonStatusIdRules()
		{
		}

		public virtual void ScheduledEndDateRules()
		{
		}

		public virtual void ScheduledStartDateRules()
		{
		}

		public virtual void StudentNoteRules()
		{
			this.RuleFor(x => x.StudentNote).Length(0, 2147483647);
		}

		public virtual void TeacherNoteRules()
		{
			this.RuleFor(x => x.TeacherNote).Length(0, 2147483647);
		}

		public virtual void StudioIdRules()
		{
			this.RuleFor(x => x.StudioId).MustAsync(this.BeValidStudio).When(x => x?.StudioId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidStudio(int id,  CancellationToken cancellationToken)
		{
			var record = await this.lessonRepository.GetStudio(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>9a1e2ac03f2a37e3f2a89d5ccfd1c384</Hash>
</Codenesium>*/