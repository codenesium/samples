using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiBadgesServerRequestModelValidator : AbstractApiBadgesServerRequestModelValidator, IApiBadgesServerRequestModelValidator
	{
		public ApiBadgesServerRequestModelValidator(IBadgesRepository badgesRepository)
			: base(badgesRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiBadgesServerRequestModel model)
		{
			this.DateRules();
			this.NameRules();
			this.UserIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBadgesServerRequestModel model)
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
    <Hash>a44733b3b5865e6d650e0fc78bcbb3ca</Hash>
</Codenesium>*/