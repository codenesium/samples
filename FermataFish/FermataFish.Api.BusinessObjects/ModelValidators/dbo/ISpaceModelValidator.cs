using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface ISpaceModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(SpaceModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, SpaceModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>004e52a5be2325f84eb73f8c615d275e</Hash>
</Codenesium>*/