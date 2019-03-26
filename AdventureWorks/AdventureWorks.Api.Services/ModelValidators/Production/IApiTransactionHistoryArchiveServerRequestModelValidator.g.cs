using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiTransactionHistoryArchiveServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTransactionHistoryArchiveServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionHistoryArchiveServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>24ca17825e7ce71d43a00cb189a33e03</Hash>
</Codenesium>*/