using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IPetModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(PetModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, PetModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>50272141b7330e9ba69f7e00fb5d8317</Hash>
</Codenesium>*/