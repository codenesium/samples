using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiAirlineServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAirlineServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirlineServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e904e2651d889aefe144e0485227b7ce</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/