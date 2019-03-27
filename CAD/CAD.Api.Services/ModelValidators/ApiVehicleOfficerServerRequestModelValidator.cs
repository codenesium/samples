using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiVehicleOfficerServerRequestModelValidator : AbstractApiVehicleOfficerServerRequestModelValidator, IApiVehicleOfficerServerRequestModelValidator
	{
		public ApiVehicleOfficerServerRequestModelValidator(IVehicleOfficerRepository vehicleOfficerRepository)
			: base(vehicleOfficerRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVehicleOfficerServerRequestModel model)
		{
			this.OfficerIdRules();
			this.VehicleIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVehicleOfficerServerRequestModel model)
		{
			this.OfficerIdRules();
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
    <Hash>e7e56f935adebf01411a37a912e543df</Hash>
</Codenesium>*/