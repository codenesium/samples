using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiVoteTypesServerRequestModelValidator : AbstractApiVoteTypesServerRequestModelValidator, IApiVoteTypesServerRequestModelValidator
	{
		public ApiVoteTypesServerRequestModelValidator(IVoteTypesRepository voteTypesRepository)
			: base(voteTypesRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVoteTypesServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVoteTypesServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>27c08230e623ece6eed09a546a0e487f</Hash>
</Codenesium>*/