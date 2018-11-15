using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiErrorLogServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiErrorLogServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiErrorLogServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cfe96ff44ca9d0dbd0a2c544032e6a92</Hash>
</Codenesium>*/