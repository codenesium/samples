using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IStateModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(StateModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, StateModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f2f4e8603f06db0a981896a825773941</Hash>
</Codenesium>*/