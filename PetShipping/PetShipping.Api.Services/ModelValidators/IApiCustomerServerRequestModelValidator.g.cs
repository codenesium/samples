using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiCustomerServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCustomerServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCustomerServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7ecbabb03a6a9fddb02aa1f26b257671</Hash>
</Codenesium>*/