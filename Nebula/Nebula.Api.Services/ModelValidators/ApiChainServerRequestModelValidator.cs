using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiChainServerRequestModelValidator : AbstractApiChainServerRequestModelValidator, IApiChainServerRequestModelValidator
	{
		public ApiChainServerRequestModelValidator(IChainRepository chainRepository)
			: base(chainRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiChainServerRequestModel model)
		{
			this.ChainStatusIdRules();
			this.ExternalIdRules();
			this.NameRules();
			this.TeamIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainServerRequestModel model)
		{
			this.ChainStatusIdRules();
			this.ExternalIdRules();
			this.NameRules();
			this.TeamIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>67d3b876dba8591f2fafadc6f3534b93</Hash>
</Codenesium>*/