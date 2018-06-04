using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.Services
{
	public interface IApiAirTransportRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAirTransportRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirTransportRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>765bda239472c3b0f15df4d97208632e</Hash>
</Codenesium>*/