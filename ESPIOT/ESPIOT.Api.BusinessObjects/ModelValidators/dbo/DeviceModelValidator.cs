using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.BusinessObjects
{
	public class ApiDeviceModelValidator: AbstractApiDeviceModelValidator, IApiDeviceModelValidator
	{
		public ApiDeviceModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiDeviceModel model)
		{
			this.NameRules();
			this.PublicIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceModel model)
		{
			this.NameRules();
			this.PublicIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>15c1fc81a4bc827b1b7c928c25b2b0fe</Hash>
</Codenesium>*/