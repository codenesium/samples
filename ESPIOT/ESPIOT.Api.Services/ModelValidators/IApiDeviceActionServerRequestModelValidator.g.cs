using ESPIOTNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public partial interface IApiDeviceActionServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeviceActionServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceActionServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7d9b173135c5a8f387b63bcfa1420a63</Hash>
</Codenesium>*/