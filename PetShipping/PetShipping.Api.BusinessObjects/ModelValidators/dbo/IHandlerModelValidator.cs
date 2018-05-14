using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiHandlerModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiHandlerModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiHandlerModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>89c66135b6692c76fae1423bcbac0b3a</Hash>
</Codenesium>*/