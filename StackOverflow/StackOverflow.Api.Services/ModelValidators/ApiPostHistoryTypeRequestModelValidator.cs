using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiPostHistoryTypeRequestModelValidator : AbstractApiPostHistoryTypeRequestModelValidator, IApiPostHistoryTypeRequestModelValidator
	{
		public ApiPostHistoryTypeRequestModelValidator(IPostHistoryTypeRepository postHistoryTypeRepository)
			: base(postHistoryTypeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPostHistoryTypeRequestModel model)
		{
			this.TypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostHistoryTypeRequestModel model)
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
    <Hash>287baeff993362d49493d01d1dcf3bbd</Hash>
</Codenesium>*/