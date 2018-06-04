using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiLocationRequestModelValidator: AbstractApiLocationRequestModelValidator, IApiLocationRequestModelValidator
	{
		public ApiLocationRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiLocationRequestModel model)
		{
			this.AvailabilityRules();
			this.CostRateRules();
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(short id, ApiLocationRequestModel model)
		{
			this.AvailabilityRules();
			this.CostRateRules();
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(short id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>58d17bcb1d150728733fcda7e3f57b78</Hash>
</Codenesium>*/