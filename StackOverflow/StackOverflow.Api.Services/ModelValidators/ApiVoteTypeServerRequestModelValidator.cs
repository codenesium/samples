using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiVoteTypeServerRequestModelValidator : AbstractApiVoteTypeServerRequestModelValidator, IApiVoteTypeServerRequestModelValidator
	{
		public ApiVoteTypeServerRequestModelValidator(IVoteTypeRepository voteTypeRepository)
			: base(voteTypeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVoteTypeServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVoteTypeServerRequestModel model)
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
    <Hash>9fcdc1742a7d5c48312d21438f1f5e01</Hash>
</Codenesium>*/