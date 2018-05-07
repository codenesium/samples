using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IPetModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(PetModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, PetModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>abfd09b68894e27857444cf78d67440b</Hash>
</Codenesium>*/