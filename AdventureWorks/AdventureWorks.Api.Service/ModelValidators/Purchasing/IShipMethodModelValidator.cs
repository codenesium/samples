using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IShipMethodModelValidator
	{
		ValidationResult Validate(ShipMethodModel entity);

		Task<ValidationResult> ValidateAsync(ShipMethodModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>9d8cd183c1fac3ced94d53b5e5d18463</Hash>
</Codenesium>*/