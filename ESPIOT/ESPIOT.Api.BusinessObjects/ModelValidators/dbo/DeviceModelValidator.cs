using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.BusinessObjects
{
	public class DeviceModelValidator: AbstractDeviceModelValidator, IDeviceModelValidator
	{
		public DeviceModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(DeviceModel model)
		{
			this.PublicIdRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, DeviceModel model)
		{
			this.PublicIdRules();
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
    <Hash>6cb408a74b60ca82626766aa66faa2f2</Hash>
</Codenesium>*/