using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class SpecialOfferModelValidator: AbstractSpecialOfferModelValidator, ISpecialOfferModelValidator
	{
		public SpecialOfferModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(SpecialOfferModel model)
		{
			this.DescriptionRules();
			this.DiscountPctRules();
			this.TypeRules();
			this.CategoryRules();
			this.StartDateRules();
			this.EndDateRules();
			this.MinQtyRules();
			this.MaxQtyRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SpecialOfferModel model)
		{
			this.DescriptionRules();
			this.DiscountPctRules();
			this.TypeRules();
			this.CategoryRules();
			this.StartDateRules();
			this.EndDateRules();
			this.MinQtyRules();
			this.MaxQtyRules();
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
    <Hash>0539d92de91becd3dfeb16be5a1e49bd</Hash>
</Codenesium>*/