using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiEmployeePayHistoryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmployeePayHistoryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeePayHistoryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ceffda19b70e859934bd680b9e776cb0</Hash>
</Codenesium>*/