using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>57b9078b83e41d4bee32a16f38f554c3</Hash>
</Codenesium>*/