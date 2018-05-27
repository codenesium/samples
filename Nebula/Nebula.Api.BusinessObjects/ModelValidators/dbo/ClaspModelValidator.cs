using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class ApiClaspRequestModelValidator: AbstractApiClaspRequestModelValidator, IApiClaspRequestModelValidator
	{
		public ApiClaspRequestModelValidator()
		{   }

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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>aaa4b9f9ab6bd6515276a2e8d8c4577b</Hash>
</Codenesium>*/