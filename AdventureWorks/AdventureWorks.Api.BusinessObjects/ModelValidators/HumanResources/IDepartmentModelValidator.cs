using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiDepartmentModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDepartmentModel model);
		Task<ValidationResult> ValidateUpdateAsync(short id, ApiDepartmentModel model);
		Task<ValidationResult> ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>3c13e44c8d681444ffcdfed2a038d558</Hash>
</Codenesium>*/