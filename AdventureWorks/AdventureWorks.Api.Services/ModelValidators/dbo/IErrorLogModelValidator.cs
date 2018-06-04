using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiErrorLogRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiErrorLogRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiErrorLogRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8ddb75df6941ab03a1b353fc622d129c</Hash>
</Codenesium>*/