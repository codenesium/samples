using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiVehicleRefCapabilityServerRequestModelValidator : AbstractApiVehicleRefCapabilityServerRequestModelValidator, IApiVehicleRefCapabilityServerRequestModelValidator
	{
		public ApiVehicleRefCapabilityServerRequestModelValidator(IVehicleRefCapabilityRepository vehicleRefCapabilityRepository)
			: base(vehicleRefCapabilityRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVehicleRefCapabilityServerRequestModel model)
		{
			this.VehicleCapabilityIdRules();
			this.VehicleIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVehicleRefCapabilityServerRequestModel model)
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
    <Hash>a8af2b40cf24d29317b9a87d100fd206</Hash>
</Codenesium>*/