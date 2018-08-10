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
    <Hash>d15eb30f6cb0a84694fdb9c46cfc625b</Hash>
</Codenesium>*/