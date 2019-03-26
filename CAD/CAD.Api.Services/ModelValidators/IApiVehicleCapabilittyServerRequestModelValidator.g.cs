using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiVehicleCapabilittyServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVehicleCapabilittyServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVehicleCapabilittyServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f0eb312b0c697262cb79f6ede49e3661</Hash>
</Codenesium>*/