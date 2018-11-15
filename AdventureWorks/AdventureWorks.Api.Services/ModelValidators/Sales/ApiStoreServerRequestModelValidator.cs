using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiStoreServerRequestModelValidator : AbstractApiStoreServerRequestModelValidator, IApiStoreServerRequestModelValidator
	{
		public ApiStoreServerRequestModelValidator(IStoreRepository storeRepository)
			: base(storeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiStoreServerRequestModel model)
		{
			this.DemographicRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			this.SalesPersonIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStoreServerRequestModel model)
		{
			this.DemographicRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			this.SalesPersonIDRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>25926557066c60fee5a9c8534bb5ca77</Hash>
</Codenesium>*/