using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public class ApiStateRequestModelValidator : AbstractApiStateRequestModelValidator, IApiStateRequestModelValidator
	{
		public ApiStateRequestModelValidator(IStateRepository stateRepository)
			: base(stateRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiStateRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStateRequestModel model)
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
    <Hash>d42eb52093b3a16572c8ea86ec0226cb</Hash>
</Codenesium>*/