using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiVehCapabilityServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVehCapabilityServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVehCapabilityServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>83aa5c4ae7737fc58e215a3ae011913b</Hash>
</Codenesium>*/