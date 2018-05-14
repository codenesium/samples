using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiPersonCreditCardModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonCreditCardModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonCreditCardModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c2631bfe579c397dada91cde94113d81</Hash>
</Codenesium>*/