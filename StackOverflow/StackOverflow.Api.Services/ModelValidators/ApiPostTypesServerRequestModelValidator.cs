using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiPostTypesServerRequestModelValidator : AbstractApiPostTypesServerRequestModelValidator, IApiPostTypesServerRequestModelValidator
	{
		public ApiPostTypesServerRequestModelValidator(IPostTypesRepository postTypesRepository)
			: base(postTypesRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPostTypesServerRequestModel model)
		{
			this.RwTypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostTypesServerRequestModel model)
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
    <Hash>f005e9a6b181c3ac392e142981cbc08e</Hash>
</Codenesium>*/