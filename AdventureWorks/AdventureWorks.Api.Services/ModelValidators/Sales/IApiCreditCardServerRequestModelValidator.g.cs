using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiCreditCardServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCreditCardServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCreditCardServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f4b32cb070e94e3595ac7a879fcfa112</Hash>
</Codenesium>*/