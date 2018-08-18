using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiVersionInfoRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVersionInfoRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(long id, ApiVersionInfoRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(long id);
	}
}

/*<Codenesium>
    <Hash>b6524a6e09b14296e82172988de363a7</Hash>
</Codenesium>*/