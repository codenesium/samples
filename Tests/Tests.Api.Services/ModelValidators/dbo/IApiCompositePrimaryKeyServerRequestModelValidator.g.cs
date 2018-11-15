using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiCompositePrimaryKeyServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCompositePrimaryKeyServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCompositePrimaryKeyServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>326655f09963df16c02f933f57b02325</Hash>
</Codenesium>*/