using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiTransactionHistoryArchiveRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTransactionHistoryArchiveRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionHistoryArchiveRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>39d664b8a4d96f90b03c434aee40f315</Hash>
</Codenesium>*/