using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Services
{
	public class ApiDeviceRequestModelValidator: AbstractApiDeviceRequestModelValidator, IApiDeviceRequestModelValidator
	{
		public ApiDeviceRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiDeviceRequestModel model)
		{
			this.NameRules();
			this.PublicIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceRequestModel model)
		{
			this.NameRules();
			this.PublicIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>b356c098ba0090693a3374cfda1e04ca</Hash>
</Codenesium>*/