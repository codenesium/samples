using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiAirlineModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAirlineModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirlineModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4c78c2f7c93373a397b8c9748f3b288d</Hash>
</Codenesium>*/