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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>249c5b8f157ee926aacc38e06891515d</Hash>
</Codenesium>*/