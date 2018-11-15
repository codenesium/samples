using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiLinkStatusServerRequestModelValidator : AbstractApiLinkStatusServerRequestModelValidator, IApiLinkStatusServerRequestModelValidator
	{
		public ApiLinkStatusServerRequestModelValidator(ILinkStatusRepository linkStatusRepository)
			: base(linkStatusRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLinkStatusServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkStatusServerRequestModel model)
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
    <Hash>eb8265b87016414a08a6b4f6a3a93d14</Hash>
</Codenesium>*/