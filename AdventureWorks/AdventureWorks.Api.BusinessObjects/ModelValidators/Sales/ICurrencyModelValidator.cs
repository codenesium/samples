using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ICurrencyModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(CurrencyModel model);
		Task<ValidationResult>  ValidateUpdateAsync(string id, CurrencyModel model);
		Task<ValidationResult>  ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>7c0015450bef0c7836b730ebb1705bcb</Hash>
</Codenesium>*/