using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiTransactionHistoryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTransactionHistoryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionHistoryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>de77a5afdcccf72bda7c5fef5e5d7d47</Hash>
</Codenesium>*/