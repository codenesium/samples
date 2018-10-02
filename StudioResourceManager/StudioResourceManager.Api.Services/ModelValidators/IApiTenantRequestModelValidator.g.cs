using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiTenantRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTenantRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTenantRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7cc82ce6bdc8b486a2acd40386c51c8c</Hash>
</Codenesium>*/