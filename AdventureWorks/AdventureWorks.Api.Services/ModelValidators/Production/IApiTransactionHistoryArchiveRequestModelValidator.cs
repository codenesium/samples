using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiTransactionHistoryArchiveRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTransactionHistoryArchiveRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionHistoryArchiveRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2c68cbc377c74cdd636dbbde46d526f9</Hash>
</Codenesium>*/