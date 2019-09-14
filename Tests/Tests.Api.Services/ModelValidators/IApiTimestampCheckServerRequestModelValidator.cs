using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiTimestampCheckServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTimestampCheckServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTimestampCheckServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3d31fb0204aece7ecd8c465a799b934b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/