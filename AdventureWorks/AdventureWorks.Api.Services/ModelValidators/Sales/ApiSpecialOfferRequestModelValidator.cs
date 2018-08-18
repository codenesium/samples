using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiSpecialOfferRequestModelValidator : AbstractApiSpecialOfferRequestModelValidator, IApiSpecialOfferRequestModelValidator
	{
		public ApiSpecialOfferRequestModelValidator(ISpecialOfferRepository specialOfferRepository)
			: base(specialOfferRepository)
		{
		}

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
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>7ab680be71547b57c5cdaeb23c17b6fa</Hash>
</Codenesium>*/