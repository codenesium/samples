using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiLinkTypesServerRequestModelValidator : AbstractApiLinkTypesServerRequestModelValidator, IApiLinkTypesServerRequestModelValidator
	{
		public ApiLinkTypesServerRequestModelValidator(ILinkTypesRepository linkTypesRepository)
			: base(linkTypesRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLinkTypesServerRequestModel model)
		{
			this.RwTypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkTypesServerRequestModel model)
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
    <Hash>c44b9fd6defbce9e207e974c952892ab</Hash>
</Codenesium>*/