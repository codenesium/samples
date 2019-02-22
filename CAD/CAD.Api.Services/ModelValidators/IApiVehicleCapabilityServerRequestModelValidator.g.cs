using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiVehicleCapabilityServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVehicleCapabilityServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVehicleCapabilityServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>613ac4bc90586b48282292f08f2a62a3</Hash>
</Codenesium>*/