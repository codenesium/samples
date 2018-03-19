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
    <Hash>d888fe94e7fa05d05ec3768ef781f272</Hash>
</Codenesium>*/