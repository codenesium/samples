using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public interface IApiSchemaBPersonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSchemaBPersonRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSchemaBPersonRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>13be5302cb2219edafc0e35eec3c0152</Hash>
</Codenesium>*/