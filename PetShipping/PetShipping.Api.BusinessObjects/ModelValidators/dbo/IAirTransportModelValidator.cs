using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IAirTransportModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(AirTransportModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, AirTransportModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>98339752c62525ccb436ac16a330025d</Hash>
</Codenesium>*/