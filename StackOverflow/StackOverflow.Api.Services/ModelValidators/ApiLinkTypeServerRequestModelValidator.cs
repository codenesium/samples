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
			this.RwTypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkTypeServerRequestModel model)
		{
			this.RwTypeRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>35e596454baa70168122c67bd4f441ec</Hash>
</Codenesium>*/