using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public interface IApiChainRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiChainRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>940376968ffa5d5876fa823cf38e7ab3</Hash>
</Codenesium>*/