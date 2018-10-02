using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiFollowingRequestModelValidator : AbstractApiFollowingRequestModelValidator, IApiFollowingRequestModelValidator
	{
		public ApiFollowingRequestModelValidator(IFollowingRepository followingRepository)
			: base(followingRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiFollowingRequestModel model)
		{
			this.DateFollowedRules();
			this.MutedRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiFollowingRequestModel model)
		{
			this.DateFollowedRules();
			this.MutedRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>0d39309121e13f842cf45231dfe5c374</Hash>
</Codenesium>*/