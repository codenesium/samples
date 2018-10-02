using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiVoteRequestModelValidator : AbstractApiVoteRequestModelValidator, IApiVoteRequestModelValidator
	{
		public ApiVoteRequestModelValidator(IVoteRepository voteRepository)
			: base(voteRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVoteRequestModel model)
		{
			this.BountyAmountRules();
			this.CreationDateRules();
			this.PostIdRules();
			this.UserIdRules();
			this.VoteTypeIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVoteRequestModel model)
		{
			this.BountyAmountRules();
			this.CreationDateRules();
			this.PostIdRules();
			this.UserIdRules();
			this.VoteTypeIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>5ea4b6658ff4204f8e22b4fb5dca8487</Hash>
</Codenesium>*/