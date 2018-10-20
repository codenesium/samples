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
			this.IsDeletedRules();
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
    <Hash>0927a3aa4dced8738baa8db01394482d</Hash>
</Codenesium>*/