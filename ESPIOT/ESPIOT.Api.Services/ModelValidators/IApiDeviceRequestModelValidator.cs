using ESPIOTNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public partial interface IApiDeviceRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeviceRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2ef00dd655c802fc7ea14fb20dfdb27b</Hash>
</Codenesium>*/