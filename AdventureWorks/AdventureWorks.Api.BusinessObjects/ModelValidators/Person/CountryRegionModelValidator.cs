using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiCountryRegionRequestModelValidator: AbstractApiCountryRegionRequestModelValidator, IApiCountryRegionRequestModelValidator
	{
		public ApiCountryRegionRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiCountryRegionRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiCountryRegionRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>c04da0cb936ec986da1dd81544515f4b</Hash>
</Codenesium>*/