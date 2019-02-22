using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiVehicleServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVehicleServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVehicleServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>660f6011bab2813ed1d83b26a03ee9df</Hash>
</Codenesium>*/