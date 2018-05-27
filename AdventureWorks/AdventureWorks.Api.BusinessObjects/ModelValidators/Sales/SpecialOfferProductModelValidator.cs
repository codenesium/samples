using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiSpecialOfferProductRequestModelValidator: AbstractApiSpecialOfferProductRequestModelValidator, IApiSpecialOfferProductRequestModelValidator
	{
		public ApiSpecialOfferProductRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSpecialOfferProductRequestModel model)
		{
			this.ModifiedDateRules();
			this.ProductIDRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpecialOfferProductRequestModel model)
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
    <Hash>cfd8ee29ed404819aee298319ae2d6c8</Hash>
</Codenesium>*/