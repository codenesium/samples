using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IAirlineModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(AirlineModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, AirlineModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1f0a8d64194717d5ebdb7a4855956f13</Hash>
</Codenesium>*/