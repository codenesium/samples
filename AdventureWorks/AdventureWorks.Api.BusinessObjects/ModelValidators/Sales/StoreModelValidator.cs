using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class StoreModelValidator: AbstractStoreModelValidator, IStoreModelValidator
	{
		public StoreModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(StoreModel model)
		{
			this.NameRules();
			this.SalesPersonIDRules();
			this.DemographicsRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, StoreModel model)
		{
			this.NameRules();
			this.SalesPersonIDRules();
			this.DemographicsRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>c9b4da1057929efe7dab82430264808b</Hash>
</Codenesium>*/