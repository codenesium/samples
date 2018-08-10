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
    <Hash>89e95782c22db58ee20b776d089a0dbf</Hash>
</Codenesium>*/