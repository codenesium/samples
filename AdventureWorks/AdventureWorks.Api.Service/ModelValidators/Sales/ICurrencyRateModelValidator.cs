using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ICurrencyRateModelValidator
	{
		ValidationResult Validate(CurrencyRateModel entity);

		Task<ValidationResult> ValidateAsync(CurrencyRateModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>e18cb0253bacdf465a30fa61d445abc3</Hash>
</Codenesium>*/