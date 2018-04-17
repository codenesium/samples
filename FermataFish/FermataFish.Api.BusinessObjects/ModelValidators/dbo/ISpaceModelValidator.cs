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
    <Hash>ba2149bf6ddd5fc6fb407b6653b102b6</Hash>
</Codenesium>*/