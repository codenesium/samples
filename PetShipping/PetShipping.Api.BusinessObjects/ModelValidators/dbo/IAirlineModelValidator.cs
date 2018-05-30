using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiAirlineRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAirlineRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirlineRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>724e163459a68e46074c47c73cc14245</Hash>
</Codenesium>*/