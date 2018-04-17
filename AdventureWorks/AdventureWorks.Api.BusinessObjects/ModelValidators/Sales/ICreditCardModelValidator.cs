using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ICreditCardModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(CreditCardModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, CreditCardModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d4fa165953410e84b792fb7cdce71b6a</Hash>
</Codenesium>*/