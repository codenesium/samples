using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiEmployeeDepartmentHistoryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmployeeDepartmentHistoryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeDepartmentHistoryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fe332e95349a3377eb7536f4d1d16fa1</Hash>
</Codenesium>*/