using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Service
{
	public interface IChainModelValidator
	{
		ValidationResult Validate(ChainModel entity);

		Task<ValidationResult> ValidateAsync(ChainModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>0318ae86a1d9976d8643cf57ec32b534</Hash>
</Codenesium>*/