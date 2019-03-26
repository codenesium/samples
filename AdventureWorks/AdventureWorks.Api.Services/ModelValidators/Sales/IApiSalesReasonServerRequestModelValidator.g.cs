using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSalesReasonServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesReasonServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesReasonServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dc010ccbd5f45ce19308401125097f67</Hash>
</Codenesium>*/