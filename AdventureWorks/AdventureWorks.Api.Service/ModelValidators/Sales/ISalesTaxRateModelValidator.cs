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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>1319eb9b73af7cf1d780c3a6703dd5f3</Hash>
</Codenesium>*/