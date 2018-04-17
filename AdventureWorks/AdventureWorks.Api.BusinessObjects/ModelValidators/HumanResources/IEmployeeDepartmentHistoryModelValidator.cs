using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IEmployeeDepartmentHistoryModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(EmployeeDepartmentHistoryModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, EmployeeDepartmentHistoryModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>23cc840585f8eeb98e0a94bdc0fcdf7e</Hash>
</Codenesium>*/