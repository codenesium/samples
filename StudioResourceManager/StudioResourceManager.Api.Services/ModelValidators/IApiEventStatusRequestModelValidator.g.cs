using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiEventStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEventStatusRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventStatusRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a8760956fa85fdc3913f14d2cfdec3f8</Hash>
</Codenesium>*/