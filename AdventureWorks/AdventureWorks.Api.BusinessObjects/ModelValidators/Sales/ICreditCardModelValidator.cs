using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ICreditCardModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(CreditCardModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, CreditCardModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5c632b6b567a3019cffcf71b42b12bfa</Hash>
</Codenesium>*/