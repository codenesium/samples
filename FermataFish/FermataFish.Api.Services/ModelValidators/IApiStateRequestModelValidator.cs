using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IApiStateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStateRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStateRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0a31c2546f04f3aeeff0be4df3b80f71</Hash>
</Codenesium>*/