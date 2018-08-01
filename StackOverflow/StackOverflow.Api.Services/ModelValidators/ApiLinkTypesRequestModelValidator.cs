using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiLinkTypesRequestModelValidator : AbstractApiLinkTypesRequestModelValidator, IApiLinkTypesRequestModelValidator
	{
		public ApiLinkTypesRequestModelValidator(ILinkTypesRepository linkTypesRepository)
			: base(linkTypesRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLinkTypesRequestModel model)
		{
			this.TypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkTypesRequestModel model)
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
    <Hash>cabe52aa1d802739bd84480fcbded01d</Hash>
</Codenesium>*/