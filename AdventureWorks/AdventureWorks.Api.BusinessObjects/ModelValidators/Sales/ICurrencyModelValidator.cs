using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ICurrencyModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(CurrencyModel model);
		Task<ValidationResult> ValidateUpdateAsync(string id, CurrencyModel model);
		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>0e7441ec596bee70f94c99bbc892305f</Hash>
</Codenesium>*/