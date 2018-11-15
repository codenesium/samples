using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiLinkLogServerRequestModelValidator : AbstractApiLinkLogServerRequestModelValidator, IApiLinkLogServerRequestModelValidator
	{
		public ApiLinkLogServerRequestModelValidator(ILinkLogRepository linkLogRepository)
			: base(linkLogRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLinkLogServerRequestModel model)
		{
			this.DateEnteredRules();
			this.LinkIdRules();
			this.LogRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkLogServerRequestModel model)
		{
			this.DateEnteredRules();
			this.LinkIdRules();
			this.LogRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>072c0ac316385f24f35e56df4ef05bee</Hash>
</Codenesium>*/