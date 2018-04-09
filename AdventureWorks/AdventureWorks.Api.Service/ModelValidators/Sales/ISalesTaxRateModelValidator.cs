using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ISalesTaxRateModelValidator
	{
		ValidationResult Validate(SalesTaxRateModel entity);

		Task<ValidationResult> ValidateAsync(SalesTaxRateModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>24fc100da7f422b43f66387dcc6bce45</Hash>
</Codenesium>*/