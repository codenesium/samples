using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
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
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>e5b3e91d618b2ee7a3dabdb4473a5484</Hash>
</Codenesium>*/