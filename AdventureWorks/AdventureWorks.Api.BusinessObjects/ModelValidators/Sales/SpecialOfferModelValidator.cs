using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiSpecialOfferRequestModelValidator: AbstractApiSpecialOfferRequestModelValidator, IApiSpecialOfferRequestModelValidator
	{
		public ApiSpecialOfferRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSpecialOfferRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpecialOfferRequestModel model)
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
    <Hash>3083508302efb48a49f7b80bffc74fde</Hash>
</Codenesium>*/