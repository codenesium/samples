using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IProductCostHistoryModelValidator
	{
		ValidationResult Validate(ProductCostHistoryModel entity);

		Task<ValidationResult> ValidateAsync(ProductCostHistoryModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>a63c4c08afed8fcd0ccf9a6a47b3d680</Hash>
</Codenesium>*/