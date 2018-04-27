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
			this.DemographicsRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			this.SalesPersonIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, StoreModel model)
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
    <Hash>873ed2077cba0a287ddd0e331ad1b7fc</Hash>
</Codenesium>*/