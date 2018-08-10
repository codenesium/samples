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
    <Hash>9c5993fbf0539d4ce685988a0dec09f4</Hash>
</Codenesium>*/