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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>569f093d1f931d49aef293ad61029e3a</Hash>
</Codenesium>*/