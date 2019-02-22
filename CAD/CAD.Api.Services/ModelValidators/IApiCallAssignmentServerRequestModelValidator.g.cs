using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiCallAssignmentServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCallAssignmentServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCallAssignmentServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9385b4d64d51eea567af2bb5eeaa1308</Hash>
</Codenesium>*/