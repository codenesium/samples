using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiBadgesRequestModelValidator : AbstractApiBadgesRequestModelValidator, IApiBadgesRequestModelValidator
	{
		public ApiBadgesRequestModelValidator(IBadgesRepository badgesRepository)
			: base(badgesRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiBadgesRequestModel model)
		{
			this.DateRules();
			this.NameRules();
			this.UserIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBadgesRequestModel model)
		{
			this.DateRules();
			this.NameRules();
			this.UserIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>a072012853f5dc8ccde1a076268f6131</Hash>
</Codenesium>*/