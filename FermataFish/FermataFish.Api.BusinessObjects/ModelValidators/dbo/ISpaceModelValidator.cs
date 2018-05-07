using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface ISpaceModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(SpaceModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, SpaceModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c13c5aec014aeae0d6bb0f193c55034a</Hash>
</Codenesium>*/