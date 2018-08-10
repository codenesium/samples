using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiEmployeeDepartmentHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmployeeDepartmentHistoryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeDepartmentHistoryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ee220799b2dfeead84704382535fae12</Hash>
</Codenesium>*/