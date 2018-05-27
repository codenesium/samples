using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiTransactionHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTransactionHistoryRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionHistoryRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>00d64e41c4164a20ab1c20c06db53de4</Hash>
</Codenesium>*/