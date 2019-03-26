using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiVehicleCapabilittyServerRequestModelValidator : AbstractApiVehicleCapabilittyServerRequestModelValidator, IApiVehicleCapabilittyServerRequestModelValidator
	{
		public ApiVehicleCapabilittyServerRequestModelValidator(IVehicleCapabilittyRepository vehicleCapabilittyRepository)
			: base(vehicleCapabilittyRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVehicleCapabilittyServerRequestModel model)
		{
			this.VehicleCapabilityIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVehicleCapabilittyServerRequestModel model)
		{
			this.VehicleCapabilityIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>4274531aecf2a4732f06b2827671ba2c</Hash>
</Codenesium>*/