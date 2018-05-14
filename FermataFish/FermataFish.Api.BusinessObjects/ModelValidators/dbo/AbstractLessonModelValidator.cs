using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects

{
	public abstract class AbstractApiLessonModelValidator: AbstractValidator<ApiLessonModel>
	{
		public new ValidationResult Validate(ApiLessonModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiLessonModel model)
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
			this.RuleFor(x => x.LessonStatusId).Must(this.BeValidLessonStatus).When(x => x ?.LessonStatusId != null).WithMessage("Invalid reference");
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
			this.RuleFor(x => x.StudioId).Must(this.BeValidStudio).When(x => x ?.StudioId != null).WithMessage("Invalid reference");
		}

		public virtual void TeacherNotesRules()
		{
			this.RuleFor(x => x.TeacherNotes).Length(0, 2147483647);
		}

		private bool BeValidLessonStatus(int id)
		{
			return this.LessonStatusRepository.Get(id) != null;
		}

		private bool BeValidStudio(int id)
		{
			return this.StudioRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>5105be63a59eeb18456c4b80e19c3fd4</Hash>
</Codenesium>*/