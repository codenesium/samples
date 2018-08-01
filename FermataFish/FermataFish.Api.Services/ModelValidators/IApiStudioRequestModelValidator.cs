using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public interface IApiStudioRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStudioRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudioRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d9c16e3813f363bce73ab418dbcf5816</Hash>
</Codenesium>*/