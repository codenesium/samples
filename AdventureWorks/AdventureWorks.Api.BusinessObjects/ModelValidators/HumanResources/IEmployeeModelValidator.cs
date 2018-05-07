using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IEmployeeModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(EmployeeModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, EmployeeModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8b12159a0daad9ff8e73021a848d0609</Hash>
</Codenesium>*/