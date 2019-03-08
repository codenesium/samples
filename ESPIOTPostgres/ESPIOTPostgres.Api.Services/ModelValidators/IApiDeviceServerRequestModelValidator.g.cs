using ESPIOTPostgresNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ESPIOTPostgresNS.Api.Services
{
	public partial interface IApiDeviceServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeviceServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>24f02a2c5f4458606cce592f12ff362c</Hash>
</Codenesium>*/