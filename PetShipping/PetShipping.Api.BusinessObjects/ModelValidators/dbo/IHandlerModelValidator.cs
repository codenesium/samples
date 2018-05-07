using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IHandlerModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(HandlerModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, HandlerModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>64e0d872c7425d19eb15e58ae325c59d</Hash>
</Codenesium>*/