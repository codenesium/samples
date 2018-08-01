using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public interface IApiChainStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiChainStatusRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainStatusRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>482e2f37c13de26fcb7193ea2d9e84e9</Hash>
</Codenesium>*/