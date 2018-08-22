using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IApiRateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiRateRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiRateRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1867231e95ce29d7eef6d10eba6bfecf</Hash>
</Codenesium>*/