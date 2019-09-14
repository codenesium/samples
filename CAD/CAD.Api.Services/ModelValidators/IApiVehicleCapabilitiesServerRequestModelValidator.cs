using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiVehicleCapabilitiesServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVehicleCapabilitiesServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVehicleCapabilitiesServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4e09869dbf6cfa32fcf7c9eda67f219a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/