using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiCountryRegionRequestModelValidator : AbstractApiCountryRegionRequestModelValidator, IApiCountryRegionRequestModelValidator
	{
		public ApiCountryRegionRequestModelValidator(ICountryRegionRepository countryRegionRepository)
			: base(countryRegionRepository)
		{
		}

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
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>cf18f774e22bd44bbfe9feafadcda699</Hash>
</Codenesium>*/