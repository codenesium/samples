using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSalesPersonServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesPersonServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesPersonServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>09cdbe9bb80a230a907ac832373b1c40</Hash>
</Codenesium>*/