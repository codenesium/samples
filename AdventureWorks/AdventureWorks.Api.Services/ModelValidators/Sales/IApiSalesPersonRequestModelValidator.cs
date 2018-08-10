using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSalesPersonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesPersonRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesPersonRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e533ce7bacbd870f9237f8b50d82a343</Hash>
</Codenesium>*/