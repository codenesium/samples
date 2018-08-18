using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiPostHistoryTypesRequestModelValidator : AbstractApiPostHistoryTypesRequestModelValidator, IApiPostHistoryTypesRequestModelValidator
	{
		public ApiPostHistoryTypesRequestModelValidator(IPostHistoryTypesRepository postHistoryTypesRepository)
			: base(postHistoryTypesRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPostHistoryTypesRequestModel model)
		{
			this.TypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostHistoryTypesRequestModel model)
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
    <Hash>550ba7bf2ebaaa9797dbf7011c06ba88</Hash>
</Codenesium>*/