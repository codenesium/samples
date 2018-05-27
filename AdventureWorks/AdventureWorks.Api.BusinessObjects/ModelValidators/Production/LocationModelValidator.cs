using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(short id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>e6ff27746986abf6b742bede576085d5</Hash>
</Codenesium>*/