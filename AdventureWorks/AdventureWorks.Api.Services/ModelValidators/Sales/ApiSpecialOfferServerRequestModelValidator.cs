using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiSpecialOfferServerRequestModelValidator : AbstractApiSpecialOfferServerRequestModelValidator, IApiSpecialOfferServerRequestModelValidator
	{
		public ApiSpecialOfferServerRequestModelValidator(ISpecialOfferRepository specialOfferRepository)
			: base(specialOfferRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSpecialOfferServerRequestModel model)
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
			this.ReservedTypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpecialOfferServerRequestModel model)
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
			this.ReservedTypeRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>4abf1e1f4cc66737444ff931055be4fa</Hash>
</Codenesium>*/