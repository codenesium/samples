using ESPIOTPostgresNS.Api.Contracts;
using ESPIOTPostgresNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ESPIOTPostgresNS.Api.Services
{
	public class ApiDeviceServerRequestModelValidator : AbstractApiDeviceServerRequestModelValidator, IApiDeviceServerRequestModelValidator
	{
		public ApiDeviceServerRequestModelValidator(IDeviceRepository deviceRepository)
			: base(deviceRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDeviceServerRequestModel model)
		{
			this.NameRules();
			this.PublicIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceServerRequestModel model)
		{
			this.NameRules();
			this.PublicIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>7504d19c1baf8e3881ed366e9a9588ee</Hash>
</Codenesium>*/