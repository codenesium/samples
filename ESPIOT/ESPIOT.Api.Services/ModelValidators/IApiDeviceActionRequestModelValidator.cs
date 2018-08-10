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
    <Hash>4afc5b900fd124e25abc61ec35c8867b</Hash>
</Codenesium>*/