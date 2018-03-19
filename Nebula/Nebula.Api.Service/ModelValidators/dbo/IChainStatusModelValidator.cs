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
    <Hash>940dbf1b33ae200dea539ddd91d0429b</Hash>
</Codenesium>*/