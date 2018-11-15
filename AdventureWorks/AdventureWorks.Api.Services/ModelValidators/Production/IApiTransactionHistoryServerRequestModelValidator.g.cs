using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiTransactionHistoryServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTransactionHistoryServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionHistoryServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e513fc23c2bde9d9e3f99f767b0d6f48</Hash>
</Codenesium>*/