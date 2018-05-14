using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class ApiChainModelValidator: AbstractApiChainModelValidator, IApiChainModelValidator
	{
		public ApiChainModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiChainModel model)
		{
			this.ChainStatusIdRules();
			this.ExternalIdRules();
			this.NameRules();
			this.TeamIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainModel model)
		{
			this.ChainStatusIdRules();
			this.ExternalIdRules();
			this.NameRules();
			this.TeamIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>83671bbc67f92e30050360fa57c20885</Hash>
</Codenesium>*/