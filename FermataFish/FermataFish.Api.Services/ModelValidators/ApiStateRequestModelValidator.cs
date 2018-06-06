using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public class ApiStateRequestModelValidator: AbstractApiStateRequestModelValidator, IApiStateRequestModelValidator
	{
		public ApiStateRequestModelValidator()
		{   }

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
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>c4d65d995dbae692ddf49ecd5f2a5a18</Hash>
</Codenesium>*/