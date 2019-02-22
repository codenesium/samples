using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiVehicleCapabilityServerRequestModelValidator : AbstractApiVehicleCapabilityServerRequestModelValidator, IApiVehicleCapabilityServerRequestModelValidator
	{
		public ApiVehicleCapabilityServerRequestModelValidator(IVehicleCapabilityRepository vehicleCapabilityRepository)
			: base(vehicleCapabilityRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVehicleCapabilityServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVehicleCapabilityServerRequestModel model)
		{
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
    <Hash>82833617ad45247783de7d35c5e27531</Hash>
</Codenesium>*/