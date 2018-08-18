using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiErrorLogRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiErrorLogRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiErrorLogRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bc509a8a469b5ca449d4dc6f492a9fce</Hash>
</Codenesium>*/