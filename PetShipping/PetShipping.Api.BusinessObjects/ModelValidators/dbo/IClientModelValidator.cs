using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IClientModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ClientModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ClientModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dbce0fe1d907d8aa817e8c8ec7b125c3</Hash>
</Codenesium>*/