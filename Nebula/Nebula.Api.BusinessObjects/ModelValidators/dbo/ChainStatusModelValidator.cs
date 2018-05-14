using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class ApiChainStatusModelValidator: AbstractApiChainStatusModelValidator, IApiChainStatusModelValidator
	{
		public ApiChainStatusModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiChainStatusModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainStatusModel model)
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
    <Hash>12c0e5e196e8b65a11838fd9c3c47ba3</Hash>
</Codenesium>*/