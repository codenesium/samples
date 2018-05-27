using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiEmployeePayHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmployeePayHistoryRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeePayHistoryRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d10d1c3c097719f28067fab059ce59b7</Hash>
</Codenesium>*/