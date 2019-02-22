using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiVehicleRefCapabilityServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVehicleRefCapabilityServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVehicleRefCapabilityServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8de1e0afc0de55804ae382fb6a2747c1</Hash>
</Codenesium>*/