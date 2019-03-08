using ESPIOTPostgresNS.Api.Contracts;
using ESPIOTPostgresNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ESPIOTPostgresNS.Api.Services
{
	public class ApiDeviceActionServerRequestModelValidator : AbstractApiDeviceActionServerRequestModelValidator, IApiDeviceActionServerRequestModelValidator
	{
		public ApiDeviceActionServerRequestModelValidator(IDeviceActionRepository deviceActionRepository)
			: base(deviceActionRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDeviceActionServerRequestModel model)
		{
			this.ActionRules();
			this.DeviceIdRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceActionServerRequestModel model)
		{
			this.ActionRules();
			this.DeviceIdRules();
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
    <Hash>e1d70f610cb8ca373ab5d09bc8cfd441</Hash>
</Codenesium>*/