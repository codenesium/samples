using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiEmployeeDepartmentHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmployeeDepartmentHistoryRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeDepartmentHistoryRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>297ebea213341c277ab4aa690188b3f5</Hash>
</Codenesium>*/