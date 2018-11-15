using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiVoteServerRequestModelValidator : AbstractApiVoteServerRequestModelValidator, IApiVoteServerRequestModelValidator
	{
		public ApiVoteServerRequestModelValidator(IVoteRepository voteRepository)
			: base(voteRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVoteServerRequestModel model)
		{
			this.BountyAmountRules();
			this.CreationDateRules();
			this.PostIdRules();
			this.UserIdRules();
			this.VoteTypeIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVoteServerRequestModel model)
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
    <Hash>75d1c6f6cdd1043aca2cc6375c110ba8</Hash>
</Codenesium>*/