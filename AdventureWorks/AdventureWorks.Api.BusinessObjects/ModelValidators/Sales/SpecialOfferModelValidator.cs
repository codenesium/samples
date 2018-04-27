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
			this.CategoryRules();
			this.DescriptionRules();
			this.DiscountPctRules();
			this.EndDateRules();
			this.MaxQtyRules();
			this.MinQtyRules();
			this.ModifiedDateRules();
			this.RowguidRules();
			this.StartDateRules();
			this.TypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SpecialOfferModel model)
		{
			this.CategoryRules();
			this.DescriptionRules();
			this.DiscountPctRules();
			this.EndDateRules();
			this.MaxQtyRules();
			this.MinQtyRules();
			this.ModifiedDateRules();
			this.RowguidRules();
			this.StartDateRules();
			this.TypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>f7dc6b4c1f69b73c6148a8556499d4d5</Hash>
</Codenesium>*/