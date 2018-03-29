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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>b1e1880ca1a7156a2a22b3007b2bba87</Hash>
</Codenesium>*/