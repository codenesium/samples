using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiDepartmentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDepartmentRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(short id, ApiDepartmentRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>02ed20e204ddc6a4488d161501ac77f9</Hash>
</Codenesium>*/