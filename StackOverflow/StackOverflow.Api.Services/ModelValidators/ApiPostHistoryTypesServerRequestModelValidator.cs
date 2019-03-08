using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiPostHistoryTypesServerRequestModelValidator : AbstractApiPostHistoryTypesServerRequestModelValidator, IApiPostHistoryTypesServerRequestModelValidator
	{
		public ApiPostHistoryTypesServerRequestModelValidator(IPostHistoryTypesRepository postHistoryTypesRepository)
			: base(postHistoryTypesRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPostHistoryTypesServerRequestModel model)
		{
			this.RwTypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostHistoryTypesServerRequestModel model)
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
    <Hash>755db32554d243f726c119f0cc589cf2</Hash>
</Codenesium>*/