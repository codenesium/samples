using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiCallPersonServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCallPersonServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCallPersonServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cf54ffa8e580bc903dbb572c06a4e31f</Hash>
</Codenesium>*/