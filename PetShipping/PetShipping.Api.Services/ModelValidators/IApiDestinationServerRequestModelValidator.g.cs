using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiDestinationServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDestinationServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDestinationServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>da242d89839c68defae7b6104f4e0726</Hash>
</Codenesium>*/