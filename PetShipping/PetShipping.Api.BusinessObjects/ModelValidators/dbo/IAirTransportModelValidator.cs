using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiAirTransportModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAirTransportModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirTransportModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ad74215294350b02506416105fc0c360</Hash>
</Codenesium>*/