using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiEventServerRequestModelValidator : AbstractApiEventServerRequestModelValidator, IApiEventServerRequestModelValidator
	{
		public ApiEventServerRequestModelValidator(IEventRepository eventRepository)
			: base(eventRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEventServerRequestModel model)
		{
			this.ActualEndDateRules();
			this.ActualStartDateRules();
			this.BillAmountRules();
			this.EventStatusIdRules();
			this.ScheduledEndDateRules();
			this.ScheduledStartDateRules();
			this.StudentNoteRules();
			this.TeacherNoteRules();
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
			this.StudentNoteRules();
			this.TeacherNoteRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>d07a2d051fcf307db098e5266cefaa08</Hash>
</Codenesium>*/