using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiVoteTypesRequestModelValidator : AbstractApiVoteTypesRequestModelValidator, IApiVoteTypesRequestModelValidator
	{
		public ApiVoteTypesRequestModelValidator(IVoteTypesRepository voteTypesRepository)
			: base(voteTypesRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVoteTypesRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVoteTypesRequestModel model)
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
    <Hash>0bd46064cd80c4a79632b00ae7550b66</Hash>
</Codenesium>*/