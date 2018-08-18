using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiClaspRequestModelValidator : AbstractApiClaspRequestModelValidator, IApiClaspRequestModelValidator
	{
		public ApiClaspRequestModelValidator(IClaspRepository claspRepository)
			: base(claspRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiClaspRequestModel model)
		{
			this.NextChainIdRules();
			this.PreviousChainIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiClaspRequestModel model)
		{
			this.NextChainIdRules();
			this.PreviousChainIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>8c0549a76a5bfe2314f45fb67b047d0f</Hash>
</Codenesium>*/