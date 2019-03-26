using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiEmployeeServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmployeeServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b37172a2407a6287700bad81e6302bf3</Hash>
</Codenesium>*/