using ESPIOTPostgresNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ESPIOTPostgresNS.Api.Services
{
	public partial interface IApiDeviceActionServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeviceActionServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceActionServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>91120b217bbbf6a211f2304fe72077bc</Hash>
</Codenesium>*/