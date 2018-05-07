using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IAirlineModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(AirlineModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, AirlineModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>301290782cad7574bb772bf365aea638</Hash>
</Codenesium>*/