using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiVehicleCapabilitiesServerRequestModelValidator : AbstractApiVehicleCapabilitiesServerRequestModelValidator, IApiVehicleCapabilitiesServerRequestModelValidator
	{
		public ApiVehicleCapabilitiesServerRequestModelValidator(IVehicleCapabilitiesRepository vehicleCapabilitiesRepository)
			: base(vehicleCapabilitiesRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVehicleCapabilitiesServerRequestModel model)
		{
			this.VehicleCapabilityIdRules();
			this.VehicleIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVehicleCapabilitiesServerRequestModel model)
		{
			this.VehicleCapabilityIdRules();
			this.VehicleIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>543a73f8dd6feca98162ed73c316268f</Hash>
</Codenesium>*/