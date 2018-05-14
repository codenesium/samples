using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiPetModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPetModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPetModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a730263672593b76c9f5fdeb03433d31</Hash>
</Codenesium>*/