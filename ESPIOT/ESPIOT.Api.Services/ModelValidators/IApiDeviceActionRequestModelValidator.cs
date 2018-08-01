using ESPIOTNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public interface IApiDeviceActionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeviceActionRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceActionRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>254afa71590c0966e76f992d63fb5f4f</Hash>
</Codenesium>*/