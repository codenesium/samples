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
    <Hash>5172d1bf1c0e98ae36274cca6ea0cda9</Hash>
</Codenesium>*/