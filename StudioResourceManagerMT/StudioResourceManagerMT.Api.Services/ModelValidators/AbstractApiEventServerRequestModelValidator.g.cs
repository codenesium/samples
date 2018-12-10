using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractApiEventServerRequestModelValidator : AbstractValidator<ApiEventServerRequestModel>
	{
		private int existingRecordId;

		protected IEventRepository EventRepository { get; private set; }

		public AbstractApiEventServerRequestModelValidator(IEventRepository eventRepository)
		{
			this.EventRepository = eventRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEventServerRequestModel model, int id)
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

		public virtual void EventStatusIdRules()
		{
			this.RuleFor(x => x.EventStatusId).MustAsync(this.BeValidEventStatuByEventStatusId).When(x => !x?.EventStatusId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void ScheduledEndDateRules()
		{
		}

		public virtual void ScheduledStartDateRules()
		{
		}

		public virtual void StudentNoteRules()
		{
			this.RuleFor(x => x.StudentNote).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void TeacherNoteRules()
		{
			this.RuleFor(x => x.TeacherNote).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeValidEventStatuByEventStatusId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.EventRepository.EventStatuByEventStatusId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>3b3156fcca796b364bef5b187157b66b</Hash>
</Codenesium>*/