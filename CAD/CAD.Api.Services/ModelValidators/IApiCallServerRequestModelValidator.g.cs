using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiCallServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCallServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCallServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bf8250c9c32bdfdbb9cfa3c3ccf20e5b</Hash>
</Codenesium>*/