using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiCallStatuServerRequestModelValidator : AbstractApiCallStatuServerRequestModelValidator, IApiCallStatuServerRequestModelValidator
	{
		public ApiCallStatuServerRequestModelValidator(ICallStatuRepository callStatuRepository)
			: base(callStatuRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCallStatuServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCallStatuServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>add5c515a51c9d888b3bf2ff216c4e88</Hash>
</Codenesium>*/