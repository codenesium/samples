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
			this.ModifiedDateRules();
			this.ProductIDRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SpecialOfferProductModel model)
		{
			this.ModifiedDateRules();
			this.ProductIDRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>0d62e4d832ed8ed5c2e77c9d11858d1a</Hash>
</Codenesium>*/