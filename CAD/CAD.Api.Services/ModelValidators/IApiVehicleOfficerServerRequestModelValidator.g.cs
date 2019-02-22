using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiVehicleOfficerServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVehicleOfficerServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVehicleOfficerServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>511e30ee0ea84067c34958e66bf56847</Hash>
</Codenesium>*/