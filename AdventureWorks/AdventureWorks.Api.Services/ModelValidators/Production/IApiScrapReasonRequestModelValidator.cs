using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiScrapReasonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiScrapReasonRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(short id, ApiScrapReasonRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>9fd029561b8ded82162ae61ddcf4312f</Hash>
</Codenesium>*/