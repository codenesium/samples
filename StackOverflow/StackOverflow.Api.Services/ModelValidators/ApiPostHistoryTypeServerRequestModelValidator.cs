using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiPostHistoryTypeServerRequestModelValidator : AbstractApiPostHistoryTypeServerRequestModelValidator, IApiPostHistoryTypeServerRequestModelValidator
	{
		public ApiPostHistoryTypeServerRequestModelValidator(IPostHistoryTypeRepository postHistoryTypeRepository)
			: base(postHistoryTypeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPostHistoryTypeServerRequestModel model)
		{
			this.TypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostHistoryTypeServerRequestModel model)
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
    <Hash>3adec5cf9ea1711fc98319334e9364aa</Hash>
</Codenesium>*/