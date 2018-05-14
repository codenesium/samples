using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiStudioModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStudioModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudioModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>367740e9c0ce7fe22d8784dcde7847fd</Hash>
</Codenesium>*/