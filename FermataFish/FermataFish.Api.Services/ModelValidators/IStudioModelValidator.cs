using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
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
    <Hash>dfdda098ae66c8fdf8baac85a1121cd0</Hash>
</Codenesium>*/