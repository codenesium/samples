using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ICountryRegionModelValidator
	{
		ValidationResult Validate(CountryRegionModel entity);

		Task<ValidationResult> ValidateAsync(CountryRegionModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>d18cde81c3beff4b00cd709a8ceb66df</Hash>
</Codenesium>*/