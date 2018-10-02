using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiBadgeRequestModelValidator : AbstractApiBadgeRequestModelValidator, IApiBadgeRequestModelValidator
	{
		public ApiBadgeRequestModelValidator(IBadgeRepository badgeRepository)
			: base(badgeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiBadgeRequestModel model)
		{
			this.DateRules();
			this.NameRules();
			this.UserIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBadgeRequestModel model)
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
    <Hash>5105bf154104c489dc5dcf6d42d45e58</Hash>
</Codenesium>*/