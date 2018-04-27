using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IHandlerModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(HandlerModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, HandlerModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>12a78910c9a72e5e15970d62c8d6ce68</Hash>
</Codenesium>*/