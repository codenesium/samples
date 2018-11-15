using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public class ApiDeviceActionServerRequestModelValidator : AbstractApiDeviceActionServerRequestModelValidator, IApiDeviceActionServerRequestModelValidator
	{
		public ApiDeviceActionServerRequestModelValidator(IDeviceActionRepository deviceActionRepository)
			: base(deviceActionRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDeviceActionServerRequestModel model)
		{
			this.DeviceIdRules();
			this.NameRules();
			this.@ValueRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceActionServerRequestModel model)
		{
			this.DeviceIdRules();
			this.NameRules();
			this.@ValueRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>8b2e326793771c48a1841220cfd22282</Hash>
</Codenesium>*/