using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiEmployeeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmployeeRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>655157a998c85587880fc464f6d00bc7</Hash>
</Codenesium>*/