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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>837d8ede27181378b3934aa60753c649</Hash>
</Codenesium>*/