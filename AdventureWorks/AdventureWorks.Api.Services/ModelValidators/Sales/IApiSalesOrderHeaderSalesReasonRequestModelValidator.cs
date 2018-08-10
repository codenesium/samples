using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSalesOrderHeaderSalesReasonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderHeaderSalesReasonRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderHeaderSalesReasonRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>59abe9e5a1e5e2e0405aa1cf7403ef12</Hash>
</Codenesium>*/