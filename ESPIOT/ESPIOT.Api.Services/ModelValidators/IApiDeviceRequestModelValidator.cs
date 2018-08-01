using ESPIOTNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public interface IApiDeviceRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeviceRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ca8fabb78ba1058f1ba0933966b9441d</Hash>
</Codenesium>*/