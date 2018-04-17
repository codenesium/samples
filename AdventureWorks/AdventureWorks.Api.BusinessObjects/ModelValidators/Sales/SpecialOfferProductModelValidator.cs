using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class SpecialOfferProductModelValidator: AbstractSpecialOfferProductModelValidator, ISpecialOfferProductModelValidator
	{
		public SpecialOfferProductModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(SpecialOfferProductModel model)
		{
			this.ProductIDRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SpecialOfferProductModel model)
		{
			this.ProductIDRules();
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
    <Hash>3643acecbdb897caddb2c8565826ae71</Hash>
</Codenesium>*/