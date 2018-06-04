using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
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
    <Hash>524714a4e30501404d213b5accd445cb</Hash>
</Codenesium>*/