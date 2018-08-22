using ESPIOTNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public partial interface IApiDeviceActionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeviceActionRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceActionRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>11c4fcf9dde579b3a2bffd2886ab718a</Hash>
</Codenesium>*/