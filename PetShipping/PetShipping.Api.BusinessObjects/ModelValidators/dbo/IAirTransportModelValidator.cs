using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IAirTransportModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(AirTransportModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, AirTransportModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b4b6836a2d3fa5fe8f31327ab3d2e106</Hash>
</Codenesium>*/