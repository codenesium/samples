using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IEmployeePayHistoryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(EmployeePayHistoryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, EmployeePayHistoryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2054d26622c4db85e0059f539a7b777c</Hash>
</Codenesium>*/