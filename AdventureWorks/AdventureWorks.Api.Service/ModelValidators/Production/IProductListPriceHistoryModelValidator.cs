using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IProductListPriceHistoryModelValidator
	{
		ValidationResult Validate(ProductListPriceHistoryModel entity);

		Task<ValidationResult> ValidateAsync(ProductListPriceHistoryModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>22f15725d0c7248daa82b70174e47499</Hash>
</Codenesium>*/