using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiCountryRegionServerRequestModelValidator : AbstractApiCountryRegionServerRequestModelValidator, IApiCountryRegionServerRequestModelValidator
	{
		public ApiCountryRegionServerRequestModelValidator(ICountryRegionRepository countryRegionRepository)
			: base(countryRegionRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCountryRegionServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiCountryRegionServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>95cd97525f97830c8b9dc5e88319cdfb</Hash>
</Codenesium>*/