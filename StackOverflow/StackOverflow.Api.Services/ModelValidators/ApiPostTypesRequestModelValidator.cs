using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiPostTypesRequestModelValidator : AbstractApiPostTypesRequestModelValidator, IApiPostTypesRequestModelValidator
	{
		public ApiPostTypesRequestModelValidator(IPostTypesRepository postTypesRepository)
			: base(postTypesRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPostTypesRequestModel model)
		{
			this.TypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostTypesRequestModel model)
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
    <Hash>917e76d5ad095c37d7aba25d33c930e1</Hash>
</Codenesium>*/