using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiCallStatusServerRequestModelValidator : AbstractApiCallStatusServerRequestModelValidator, IApiCallStatusServerRequestModelValidator
	{
		public ApiCallStatusServerRequestModelValidator(ICallStatusRepository callStatusRepository)
			: base(callStatusRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCallStatusServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCallStatusServerRequestModel model)
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
    <Hash>0dc6fced9e9d9a3c5c5e8e33e2e8edec</Hash>
</Codenesium>*/