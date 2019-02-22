using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiVehicleServerRequestModelValidator : AbstractApiVehicleServerRequestModelValidator, IApiVehicleServerRequestModelValidator
	{
		public ApiVehicleServerRequestModelValidator(IVehicleRepository vehicleRepository)
			: base(vehicleRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVehicleServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVehicleServerRequestModel model)
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
    <Hash>747a76dae8902760d9d0f258f991acbf</Hash>
</Codenesium>*/