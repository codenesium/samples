using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiCallStatuServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCallStatuServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCallStatuServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>91a109a50416bce98bd2e3608fcae2a1</Hash>
</Codenesium>*/