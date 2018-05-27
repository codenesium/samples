using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiAddressTypeRequestModelValidator: AbstractApiAddressTypeRequestModelValidator, IApiAddressTypeRequestModelValidator
	{
		public ApiAddressTypeRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiAddressTypeRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressTypeRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
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
    <Hash>acf7b46cea1be2925579c34648b53266</Hash>
</Codenesium>*/