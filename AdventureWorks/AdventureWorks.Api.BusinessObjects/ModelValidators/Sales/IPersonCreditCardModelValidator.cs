using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IPersonCreditCardModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(PersonCreditCardModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, PersonCreditCardModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>51539fb1b8b17392f365aee05fa8c04c</Hash>
</Codenesium>*/