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
    <Hash>3faa1832173a930a1b5e95a36dd43ee1</Hash>
</Codenesium>*/