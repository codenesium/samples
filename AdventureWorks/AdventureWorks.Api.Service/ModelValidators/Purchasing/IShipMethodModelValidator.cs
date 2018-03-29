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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>4084528d696c1cc506ce2e7745771952</Hash>
</Codenesium>*/