using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiLinkStatusRequestModelValidator : AbstractApiLinkStatusRequestModelValidator, IApiLinkStatusRequestModelValidator
	{
		public ApiLinkStatusRequestModelValidator(ILinkStatusRepository linkStatusRepository)
			: base(linkStatusRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLinkStatusRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkStatusRequestModel model)
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
    <Hash>17d03a8507fafdda64e482cae2add952</Hash>
</Codenesium>*/