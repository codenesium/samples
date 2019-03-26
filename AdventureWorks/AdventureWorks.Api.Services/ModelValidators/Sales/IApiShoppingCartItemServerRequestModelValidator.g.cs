using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiShoppingCartItemServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiShoppingCartItemServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiShoppingCartItemServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6fc1149222d1b9feec213665e06187c6</Hash>
</Codenesium>*/