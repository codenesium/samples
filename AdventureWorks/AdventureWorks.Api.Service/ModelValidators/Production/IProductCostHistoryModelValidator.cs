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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>8c0cb982cb90d2609c07eaf4a5a4bd7c</Hash>
</Codenesium>*/