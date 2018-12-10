using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiClaspServerRequestModelValidator : AbstractApiClaspServerRequestModelValidator, IApiClaspServerRequestModelValidator
	{
		public ApiClaspServerRequestModelValidator(IClaspRepository claspRepository)
			: base(claspRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiClaspServerRequestModel model)
		{
			this.NextChainIdRules();
			this.PreviousChainIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiClaspServerRequestModel model)
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
    <Hash>4c83d4ffdac7571356fa4deae6e88bbf</Hash>
</Codenesium>*/