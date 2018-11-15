using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiLinkTypeServerRequestModelValidator : AbstractApiLinkTypeServerRequestModelValidator, IApiLinkTypeServerRequestModelValidator
	{
		public ApiLinkTypeServerRequestModelValidator(ILinkTypeRepository linkTypeRepository)
			: base(linkTypeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLinkTypeServerRequestModel model)
		{
			this.TypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkTypeServerRequestModel model)
		{
			this.TypeRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>dc681c9ef0ebae5e5f0bd5ed11bc7e04</Hash>
</Codenesium>*/