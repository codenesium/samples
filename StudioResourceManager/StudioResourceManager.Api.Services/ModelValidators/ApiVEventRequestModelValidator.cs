using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiVEventRequestModelValidator : AbstractApiVEventRequestModelValidator, IApiVEventRequestModelValidator
	{
		public ApiVEventRequestModelValidator(IVEventRepository vEventRepository)
			: base(vEventRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVEventRequestModel model)
		{
			this.ActualEndDateRules();
			this.ActualStartDateRules();
			this.BillAmountRules();
			this.EventStatusIdRules();
			this.ScheduledEndDateRules();
			this.ScheduledStartDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVEventRequestModel model)
		{
			this.ActualEndDateRules();
			this.ActualStartDateRules();
			this.BillAmountRules();
			this.EventStatusIdRules();
			this.ScheduledEndDateRules();
			this.ScheduledStartDateRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>9b2ba22e89f6a92f27c58df7082903dc</Hash>
</Codenesium>*/