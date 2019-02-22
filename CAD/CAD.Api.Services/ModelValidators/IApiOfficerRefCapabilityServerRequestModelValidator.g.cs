using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiOfficerRefCapabilityServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiOfficerRefCapabilityServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiOfficerRefCapabilityServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>db5e6f65bbdb06c567692e60913027ea</Hash>
</Codenesium>*/