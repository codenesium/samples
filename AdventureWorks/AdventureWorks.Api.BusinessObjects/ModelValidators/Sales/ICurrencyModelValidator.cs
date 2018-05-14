using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiCurrencyModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCurrencyModel model);
		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCurrencyModel model);
		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>4aaa2b1461a4debae6d3419ef65dc628</Hash>
</Codenesium>*/