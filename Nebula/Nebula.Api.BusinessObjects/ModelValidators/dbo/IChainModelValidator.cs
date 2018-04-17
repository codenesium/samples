using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IChainModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ChainModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ChainModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2573189bcefe163edcf07cc1f878b0a2</Hash>
</Codenesium>*/