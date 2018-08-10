using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiChainRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiChainRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>55f3e64f5fe227f3328ba4f335e9a6b3</Hash>
</Codenesium>*/