using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiDepartmentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDepartmentRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(short id, ApiDepartmentRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>d7db66fe75fe43c8cf9138e5e7447b93</Hash>
</Codenesium>*/