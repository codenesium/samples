using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IClientModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ClientModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ClientModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e95106e5b0b7665db6e6fe7840af4ef1</Hash>
</Codenesium>*/