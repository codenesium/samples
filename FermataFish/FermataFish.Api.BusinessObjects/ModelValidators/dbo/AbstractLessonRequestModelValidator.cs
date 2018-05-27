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
	public abstract class AbstractApiLessonRequestModelValidator: AbstractValidator<ApiLessonRequestModel>
	{
		public new ValidationResult Validate(ApiLessonRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiLessonRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ILessonStatusRepository LessonStatusRepository { get; set; }
		public IStudioRepository StudioRepository { get; set; }
		public virtual void ActualEndDateRules()
		{                       }

		public virtual void ActualStartDateRules()
		{                       }

		public virtual void BillAmountRules()
		{                       }

		public virtual void LessonStatusIdRules()
		{
			this.RuleFor(x => x.LessonStatusId).NotNull();
			this.RuleFor(x => x.LessonStatusId).MustAsync(this.BeValidLessonStatus).When(x => x ?.LessonStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void ScheduledEndDateRules()
		{                       }

		public virtual void ScheduledStartDateRules()
		{                       }

		public virtual void StudentNotesRules()
		{
			this.RuleFor(x => x.StudentNotes).Length(0, 2147483647);
		}

		public virtual void StudioIdRules()
		{
			this.RuleFor(x => x.StudioId).NotNull();
			this.RuleFor(x => x.StudioId).MustAsync(this.BeValidStudio).When(x => x ?.StudioId != null).WithMessage("Invalid reference");
		}

		public virtual void TeacherNotesRules()
		{
			this.RuleFor(x => x.TeacherNotes).Length(0, 2147483647);
		}

		private async Task<bool> BeValidLessonStatus(int id,  CancellationToken cancellationToken)
		{
			var record = await this.LessonStatusRepository.Get(id);

			return record != null;
		}

		private async Task<bool> BeValidStudio(int id,  CancellationToken cancellationToken)
		{
			var record = await this.StudioRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>7d4d8d702c414c49b27f4ac2d76dad99</Hash>
</Codenesium>*/