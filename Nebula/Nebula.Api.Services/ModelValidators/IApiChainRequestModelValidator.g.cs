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
    <Hash>c83130c25288261d5c07f64bd414a76a</Hash>
</Codenesium>*/