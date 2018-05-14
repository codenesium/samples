using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiStoreModelValidator: AbstractApiStoreModelValidator, IApiStoreModelValidator
	{
		public ApiStoreModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiStoreModel model)
		{
			this.DemographicsRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			this.SalesPersonIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStoreModel model)
		{
			this.DemographicsRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			this.SalesPersonIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>edc6d6e6d98a0f4de9a47f27577c4ce4</Hash>
</Codenesium>*/