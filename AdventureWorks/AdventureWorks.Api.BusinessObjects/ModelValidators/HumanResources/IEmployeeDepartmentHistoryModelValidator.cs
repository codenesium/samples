using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IEmployeeDepartmentHistoryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(EmployeeDepartmentHistoryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, EmployeeDepartmentHistoryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f9e6ec33cf59be7b18c3e96594c15dc0</Hash>
</Codenesium>*/