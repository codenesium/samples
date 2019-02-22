using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiCallDispositionServerRequestModelValidator : AbstractApiCallDispositionServerRequestModelValidator, IApiCallDispositionServerRequestModelValidator
	{
		public ApiCallDispositionServerRequestModelValidator(ICallDispositionRepository callDispositionRepository)
			: base(callDispositionRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCallDispositionServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCallDispositionServerRequestModel model)
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
    <Hash>672954f658dfdf3b69e27c46710d75c0</Hash>
</Codenesium>*/