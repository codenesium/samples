using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiChainStatusServerRequestModelValidator : AbstractApiChainStatusServerRequestModelValidator, IApiChainStatusServerRequestModelValidator
	{
		public ApiChainStatusServerRequestModelValidator(IChainStatusRepository chainStatusRepository)
			: base(chainStatusRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiChainStatusServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainStatusServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>a056a9dc18421fdefb7569bc152f4140</Hash>
</Codenesium>*/