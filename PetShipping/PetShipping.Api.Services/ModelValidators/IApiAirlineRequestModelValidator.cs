using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public interface IApiAirlineRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAirlineRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirlineRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8b46e4b23980d39faea85f4cd987044f</Hash>
</Codenesium>*/