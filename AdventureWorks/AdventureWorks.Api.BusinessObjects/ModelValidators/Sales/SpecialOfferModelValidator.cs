using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiSpecialOfferModelValidator: AbstractApiSpecialOfferModelValidator, IApiSpecialOfferModelValidator
	{
		public ApiSpecialOfferModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSpecialOfferModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpecialOfferModel model)
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
    <Hash>90adefa7932255076ffd78b505d13e85</Hash>
</Codenesium>*/