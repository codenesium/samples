using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiClientRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiClientRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d14ba5920b00d36258a02b899252c005</Hash>
</Codenesium>*/