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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>d9d9fa6e2479c56bc3b12543ad22f0bb</Hash>
</Codenesium>*/