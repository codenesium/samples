using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiVotesServerRequestModelValidator : AbstractApiVotesServerRequestModelValidator, IApiVotesServerRequestModelValidator
	{
		public ApiVotesServerRequestModelValidator(IVotesRepository votesRepository)
			: base(votesRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVotesServerRequestModel model)
		{
			this.BountyAmountRules();
			this.CreationDateRules();
			this.PostIdRules();
			this.UserIdRules();
			this.VoteTypeIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVotesServerRequestModel model)
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
    <Hash>4aad70e974d906ff3fc88b213c7ab7d2</Hash>
</Codenesium>*/