using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IPersonCreditCardModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(PersonCreditCardModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, PersonCreditCardModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>395b6c7d12dc763f440df6e1a3a51582</Hash>
</Codenesium>*/