using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiTransactionHistoryArchiveRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTransactionHistoryArchiveRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionHistoryArchiveRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c7426e1dc5c398ddea2e708087d4dcbe</Hash>
</Codenesium>*/