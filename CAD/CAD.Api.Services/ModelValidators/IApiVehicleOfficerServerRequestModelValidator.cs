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
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/