using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiTimestampCheckRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTimestampCheckRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTimestampCheckRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d1b2d9b3c50894da6bffa53954aece78</Hash>
</Codenesium>*/