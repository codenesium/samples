using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiFollowingServerRequestModelValidator : AbstractApiFollowingServerRequestModelValidator, IApiFollowingServerRequestModelValidator
	{
		public ApiFollowingServerRequestModelValidator(IFollowingRepository followingRepository)
			: base(followingRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiFollowingServerRequestModel model)
		{
			this.DateFollowedRules();
			this.MutedRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiFollowingServerRequestModel model)
		{
			this.DateFollowedRules();
			this.MutedRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>c715192b38f5adfb515f93478a21e1ae</Hash>
</Codenesium>*/