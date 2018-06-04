using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Services
{
	public interface IApiRateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiRateRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiRateRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>176e5947c3ddedd578d0eb0ffd4a9472</Hash>
</Codenesium>*/