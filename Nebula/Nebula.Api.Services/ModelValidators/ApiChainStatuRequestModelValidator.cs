using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiChainStatuRequestModelValidator : AbstractApiChainStatuRequestModelValidator, IApiChainStatuRequestModelValidator
	{
		public ApiChainStatuRequestModelValidator(IChainStatuRepository chainStatuRepository)
			: base(chainStatuRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiChainStatuRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainStatuRequestModel model)
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
    <Hash>ab67ca518fa861d00e65cbdd5152282b</Hash>
</Codenesium>*/