using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IEmployeePayHistoryModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(EmployeePayHistoryModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, EmployeePayHistoryModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>579d99d9ab912d4797afa3b32291901b</Hash>
</Codenesium>*/