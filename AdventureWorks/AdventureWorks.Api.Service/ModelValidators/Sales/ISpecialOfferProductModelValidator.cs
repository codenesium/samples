using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ISpecialOfferProductModelValidator
	{
		ValidationResult Validate(SpecialOfferProductModel entity);

		Task<ValidationResult> ValidateAsync(SpecialOfferProductModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>6c459c7f549e1cb66330399feabc15aa</Hash>
</Codenesium>*/