using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSalesReasonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesReasonRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesReasonRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c6b2f1ec7fa3066b70d04c894dbb3a07</Hash>
</Codenesium>*/