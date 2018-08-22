using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiCurrencyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCurrencyRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCurrencyRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>a8b84c20198c66a831012b292524092b</Hash>
</Codenesium>*/