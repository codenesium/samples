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
    <Hash>a4cbda873450c131d63d064b712f9cb2</Hash>
</Codenesium>*/