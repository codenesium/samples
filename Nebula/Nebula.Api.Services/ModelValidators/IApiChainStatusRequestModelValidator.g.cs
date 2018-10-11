using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiChainStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiChainStatusRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainStatusRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7c7f100458e3896c3791f690e75739ab</Hash>
</Codenesium>*/