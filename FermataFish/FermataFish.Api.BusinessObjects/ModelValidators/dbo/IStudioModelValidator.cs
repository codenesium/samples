using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiStudioRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStudioRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudioRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4274eae54b39fd2e7455596b1c048fdc</Hash>
</Codenesium>*/