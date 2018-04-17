using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IFamilyModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(FamilyModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, FamilyModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d210b1edb8a2bae4b880afe9955458de</Hash>
</Codenesium>*/