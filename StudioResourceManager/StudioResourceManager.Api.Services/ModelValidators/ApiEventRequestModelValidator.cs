using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiEventRequestModelValidator : AbstractApiEventRequestModelValidator, IApiEventRequestModelValidator
	{
		public ApiEventRequestModelValidator(IEventRepository eventRepository)
			: base(eventRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEventRequestModel model)
		{
			this.ActualEndDateRules();
			this.ActualStartDateRules();
			this.BillAmountRules();
			this.EventStatusIdRules();
			this.ScheduledEndDateRules();
			this.ScheduledStartDateRules();
			this.StudentNoteRules();
			this.TeacherNoteRules();
			this.IsDeletedRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventRequestModel model)
		{
			this.ActualEndDateRules();
			this.ActualStartDateRules();
			this.BillAmountRules();
			this.EventStatusIdRules();
			this.ScheduledEndDateRules();
			this.ScheduledStartDateRules();
			this.StudentNoteRules();
			this.TeacherNoteRules();
			this.IsDeletedRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>f27d3303b9782bc29dfddb0ca6b55ff2</Hash>
</Codenesium>*/