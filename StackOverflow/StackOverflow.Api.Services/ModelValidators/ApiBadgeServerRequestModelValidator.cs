using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiBadgeServerRequestModelValidator : AbstractApiBadgeServerRequestModelValidator, IApiBadgeServerRequestModelValidator
	{
		public ApiBadgeServerRequestModelValidator(IBadgeRepository badgeRepository)
			: base(badgeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiBadgeServerRequestModel model)
		{
			this.DateRules();
			this.NameRules();
			this.UserIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBadgeServerRequestModel model)
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
    <Hash>bc714719863f7627cd4ca794ae5213a3</Hash>
</Codenesium>*/