using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>1900648fc758ed10600c2b275ed609d4</Hash>
</Codenesium>*/