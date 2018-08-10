using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiTableRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTableRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTableRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7ba118dee77bf6d3900d6cf73787e5d2</Hash>
</Codenesium>*/