using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiVoteTypeRequestModelValidator : AbstractApiVoteTypeRequestModelValidator, IApiVoteTypeRequestModelValidator
	{
		public ApiVoteTypeRequestModelValidator(IVoteTypeRepository voteTypeRepository)
			: base(voteTypeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVoteTypeRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVoteTypeRequestModel model)
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
    <Hash>5160b21a708823cc329bee73234c5dcc</Hash>
</Codenesium>*/