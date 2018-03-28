using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Service
{
	public interface IChainStatusModelValidator
	{
		ValidationResult Validate(ChainStatusModel entity);

		Task<ValidationResult> ValidateAsync(ChainStatusModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>d43d2c43138c7a359fa5acc58b6ce07b</Hash>
</Codenesium>*/