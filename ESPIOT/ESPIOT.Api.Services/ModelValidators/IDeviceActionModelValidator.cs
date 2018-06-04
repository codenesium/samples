using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using ESPIOTNS.Api.Contracts;
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
    <Hash>c3136ef97eb420d8d051118c0289bf52</Hash>
</Codenesium>*/