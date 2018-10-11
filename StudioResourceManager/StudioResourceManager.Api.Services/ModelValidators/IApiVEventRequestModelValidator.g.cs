using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiVEventRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVEventRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVEventRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7ae71a33ad5b81a0481c13e2e087e67e</Hash>
</Codenesium>*/