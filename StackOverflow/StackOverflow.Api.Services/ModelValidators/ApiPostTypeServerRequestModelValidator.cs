using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiPostTypeServerRequestModelValidator : AbstractApiPostTypeServerRequestModelValidator, IApiPostTypeServerRequestModelValidator
	{
		public ApiPostTypeServerRequestModelValidator(IPostTypeRepository postTypeRepository)
			: base(postTypeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPostTypeServerRequestModel model)
		{
			this.TypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostTypeServerRequestModel model)
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
    <Hash>fa6008e88404c8fb93b5f6e1637e22a1</Hash>
</Codenesium>*/