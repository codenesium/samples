using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiCurrencyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCurrencyRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCurrencyRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>914d760f431917a423b8827f41e1cff9</Hash>
</Codenesium>*/