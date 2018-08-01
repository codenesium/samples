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
    <Hash>bb5fb8088c8365e5910d546d11cc7af1</Hash>
</Codenesium>*/