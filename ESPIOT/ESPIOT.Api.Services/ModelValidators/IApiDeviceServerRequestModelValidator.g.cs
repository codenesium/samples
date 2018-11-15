using ESPIOTNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public partial interface IApiDeviceServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeviceServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8eed21f05826f19c54fb9d710e7e0387</Hash>
</Codenesium>*/