using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiClientModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiClientModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>70e0bd020e6700cbe596c4b3931c3531</Hash>
</Codenesium>*/