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
    <Hash>80c0c1442a58bf79f81b0287d0ea1ad4</Hash>
</Codenesium>*/