using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>150dd0053578ddcca9e86290318bce0d</Hash>
</Codenesium>*/