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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>271b933eef57b6b17b39fff45d27047e</Hash>
</Codenesium>*/