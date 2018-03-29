using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ICreditCardModelValidator
	{
		ValidationResult Validate(CreditCardModel entity);

		Task<ValidationResult> ValidateAsync(CreditCardModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>c3eb4644e098b73bd53334625a4e32bd</Hash>
</Codenesium>*/