using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiProductInventoryModelValidator: AbstractApiProductInventoryModelValidator, IApiProductInventoryModelValidator
	{
		public ApiProductInventoryModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductInventoryModel model)
		{
			this.BinRules();
			this.LocationIDRules();
			this.ModifiedDateRules();
			this.QuantityRules();
			this.RowguidRules();
			this.ShelfRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductInventoryModel model)
		{
			this.BinRules();
			this.LocationIDRules();
			this.ModifiedDateRules();
			this.QuantityRules();
			this.RowguidRules();
			this.ShelfRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>2bde76e96b77295c4a0a172f40d03723</Hash>
</Codenesium>*/