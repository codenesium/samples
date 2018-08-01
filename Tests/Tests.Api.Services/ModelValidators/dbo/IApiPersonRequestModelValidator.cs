using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public interface IApiPersonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>87708bfc45fd3a80afec27f56b197e06</Hash>
</Codenesium>*/