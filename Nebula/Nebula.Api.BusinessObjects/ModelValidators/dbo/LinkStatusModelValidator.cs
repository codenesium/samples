using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class ApiLinkStatusRequestModelValidator: AbstractApiLinkStatusRequestModelValidator, IApiLinkStatusRequestModelValidator
	{
		public ApiLinkStatusRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiLinkStatusRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkStatusRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>b7d0b54d4a53f56873fcf4b9fad2a93e</Hash>
</Codenesium>*/