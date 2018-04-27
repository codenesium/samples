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
			this.NameRules();
			this.PublicIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, DeviceModel model)
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
    <Hash>c51762d7254ce4fd4ec66b2213440d0e</Hash>
</Codenesium>*/