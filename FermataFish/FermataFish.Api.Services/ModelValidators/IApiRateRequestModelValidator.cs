using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>aa1357704a7964ddffe6102bb45c6926</Hash>
</Codenesium>*/