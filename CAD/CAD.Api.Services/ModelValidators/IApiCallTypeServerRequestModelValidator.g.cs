using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiCallTypeServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCallTypeServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCallTypeServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7bf31e52345eb030d5849f1da5a5f6c5</Hash>
</Codenesium>*/