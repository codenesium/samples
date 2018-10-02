using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiPostTypeRequestModelValidator : AbstractApiPostTypeRequestModelValidator, IApiPostTypeRequestModelValidator
	{
		public ApiPostTypeRequestModelValidator(IPostTypeRepository postTypeRepository)
			: base(postTypeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPostTypeRequestModel model)
		{
			this.TypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostTypeRequestModel model)
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
    <Hash>93a88be428df7781d9b5cd228a85a6bc</Hash>
</Codenesium>*/