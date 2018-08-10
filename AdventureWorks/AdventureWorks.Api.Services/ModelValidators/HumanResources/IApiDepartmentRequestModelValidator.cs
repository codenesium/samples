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
    <Hash>c2d0cf732865b65cd0117817fc72ea2d</Hash>
</Codenesium>*/