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
			this.RuleFor(x => x.LessonStatusId).MustAsync(this.BeValidLessonStatus).When(x => x?.LessonStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void ScheduledEndDateRules()
		{
		}

		public virtual void ScheduledStartDateRules()
		{
		}

		public virtual void StudentNotesRules()
		{
			this.RuleFor(x => x.StudentNotes).Length(0, 2147483647);
		}

		public virtual void StudioIdRules()
		{
			this.RuleFor(x => x.StudioId).MustAsync(this.BeValidStudio).When(x => x?.StudioId != null).WithMessage("Invalid reference");
		}

		public virtual void TeacherNotesRules()
		{
			this.RuleFor(x => x.TeacherNotes).Length(0, 2147483647);
		}

		private async Task<bool> BeValidLessonStatus(int id,  CancellationToken cancellationToken)
		{
			var record = await this.lessonRepository.GetLessonStatus(id);

			return record != null;
		}

		private async Task<bool> BeValidStudio(int id,  CancellationToken cancellationToken)
		{
			var record = await this.lessonRepository.GetStudio(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>13ebea5d74938aeb2399ba3bc824d85d</Hash>
</Codenesium>*/