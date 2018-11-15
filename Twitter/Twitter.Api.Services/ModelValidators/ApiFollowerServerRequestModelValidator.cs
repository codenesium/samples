using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiFollowerServerRequestModelValidator : AbstractApiFollowerServerRequestModelValidator, IApiFollowerServerRequestModelValidator
	{
		public ApiFollowerServerRequestModelValidator(IFollowerRepository followerRepository)
			: base(followerRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiFollowerServerRequestModel model)
		{
			this.BlockedRules();
			this.DateFollowedRules();
			this.FollowRequestStatuRules();
			this.FollowedUserIdRules();
			this.FollowingUserIdRules();
			this.MutedRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiFollowerServerRequestModel model)
		{
			this.BlockedRules();
			this.DateFollowedRules();
			this.FollowRequestStatuRules();
			this.FollowedUserIdRules();
			this.FollowingUserIdRules();
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
    <Hash>ef9bf67228b52cd32265c96d5d303479</Hash>
</Codenesium>*/