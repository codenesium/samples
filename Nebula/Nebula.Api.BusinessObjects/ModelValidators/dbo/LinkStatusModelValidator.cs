using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class ApiLinkStatusModelValidator: AbstractApiLinkStatusModelValidator, IApiLinkStatusModelValidator
	{
		public ApiLinkStatusModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiLinkStatusModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkStatusModel model)
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
    <Hash>947500f8a04266f7e2ec8883152500a2</Hash>
</Codenesium>*/