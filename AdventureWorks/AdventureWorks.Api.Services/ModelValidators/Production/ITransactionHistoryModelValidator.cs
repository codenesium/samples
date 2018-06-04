using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiTransactionHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTransactionHistoryRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionHistoryRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>35fde8b7fdbf72c23d7b77f6c08f28e3</Hash>
</Codenesium>*/