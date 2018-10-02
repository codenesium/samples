using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiLinkTypeRequestModelValidator : AbstractApiLinkTypeRequestModelValidator, IApiLinkTypeRequestModelValidator
	{
		public ApiLinkTypeRequestModelValidator(ILinkTypeRepository linkTypeRepository)
			: base(linkTypeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLinkTypeRequestModel model)
		{
			this.TypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkTypeRequestModel model)
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
    <Hash>195320431f963d5c19663613aa8b918e</Hash>
</Codenesium>*/