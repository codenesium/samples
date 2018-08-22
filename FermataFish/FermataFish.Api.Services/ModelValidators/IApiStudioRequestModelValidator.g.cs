using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IApiStudioRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStudioRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudioRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8ae250e3365db61543f84caadc8ff7bd</Hash>
</Codenesium>*/