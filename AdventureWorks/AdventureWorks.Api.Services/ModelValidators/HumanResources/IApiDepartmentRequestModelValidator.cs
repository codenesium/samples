using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiDepartmentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDepartmentRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(short id, ApiDepartmentRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>cfd05bbc5a79b1b03946167668bd19af</Hash>
</Codenesium>*/