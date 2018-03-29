using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ISpecialOfferModelValidator
	{
		ValidationResult Validate(SpecialOfferModel entity);

		Task<ValidationResult> ValidateAsync(SpecialOfferModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>e517fe1efd46809297e26da2b8132aa8</Hash>
</Codenesium>*/