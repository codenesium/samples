using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiSchemaBPersonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSchemaBPersonRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSchemaBPersonRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d8dd363ae1ac428c9b2ea733e748a86f</Hash>
</Codenesium>*/