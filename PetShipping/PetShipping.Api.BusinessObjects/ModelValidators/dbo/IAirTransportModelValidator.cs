using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiAirTransportRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAirTransportRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirTransportRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>39f965768fdc493c59e5a6315240d167</Hash>
</Codenesium>*/