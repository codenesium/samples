using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiCurrencyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCurrencyRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCurrencyRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>2aa23c8649758a264eda10dcac2e39b6</Hash>
</Codenesium>*/