using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IStudioModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(StudioModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, StudioModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e0608ac9a479bb308c36bc22e5eef34f</Hash>
</Codenesium>*/