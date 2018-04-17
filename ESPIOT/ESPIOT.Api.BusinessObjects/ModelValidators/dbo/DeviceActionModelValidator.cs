using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.BusinessObjects
{
	public class DeviceActionModelValidator: AbstractDeviceActionModelValidator, IDeviceActionModelValidator
	{
		public DeviceActionModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(DeviceActionModel model)
		{
			this.DeviceIdRules();
			this.NameRules();
			this.@ValueRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, DeviceActionModel model)
		{
			this.DeviceIdRules();
			this.NameRules();
			this.@ValueRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>96f4facaadb3a2c50f20de00ac5d5c43</Hash>
</Codenesium>*/