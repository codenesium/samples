using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IDestinationModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(DestinationModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, DestinationModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d4294cb9d8a10d668a3d418cb16f8e3d</Hash>
</Codenesium>*/