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
	public class ApiEventServerRequestModelValidator : AbstractValidator<ApiEventServerRequestModel>, IApiEventServerRequestModelValidator
	{
		private int existingRecordId;

		protected IEventRepository EventRepository { get; private set; }

		public ApiEventServerRequestModelValidator(IEventRepository eventRepository)
		{
			this.EventRepository = eventRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEventServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEventServerRequestModel model)
		{
			this.ActualEndDateRules();
			this.ActualStartDateRules();
			this.BillAmountRules();
			this.EventStatusIdRules();
			this.ScheduledEndDateRules();
			this.ScheduledStartDateRules();
			this.StudentNotesRules();
			this.TeacherNotesRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventServerRequestModel model)
		{
			this.ActualEndDateRules();
			this.ActualStartDateRules();
			this.BillAmountRules();
			this.EventStatusIdRules();
			this.ScheduledEndDateRules();
			this.ScheduledStartDateRules();
			this.StudentNotesRules();
			this.TeacherNotesRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
			this.RuleFor(x => x.EventStatusId).MustAsync(this.BeValidEventStatusByEventStatusId).When(x => !x?.EventStatusId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void ScheduledEndDateRules()
		{
		}

		public virtual void ScheduledStartDateRules()
		{
		}

		public virtual void StudentNotesRules()
		{
			this.RuleFor(x => x.StudentNotes).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void TeacherNotesRules()
		{
			this.RuleFor(x => x.TeacherNotes).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeValidEventStatusByEventStatusId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.EventRepository.EventStatusByEventStatusId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>b5867f5020b6e7cec9044dc630d25eea</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/