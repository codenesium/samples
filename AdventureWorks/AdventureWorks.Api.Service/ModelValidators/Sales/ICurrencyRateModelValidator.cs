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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>5410c8c83ea07a7202c841d2e3eaacd3</Hash>
</Codenesium>*/