using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiAirTransportServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAirTransportServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirTransportServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2fd445e436993b540e3ce3a434550921</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/