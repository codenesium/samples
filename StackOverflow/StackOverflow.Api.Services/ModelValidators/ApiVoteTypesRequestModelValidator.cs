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
    <Hash>ab00c94a592017811ce9c7e6fe03eaa7</Hash>
</Codenesium>*/