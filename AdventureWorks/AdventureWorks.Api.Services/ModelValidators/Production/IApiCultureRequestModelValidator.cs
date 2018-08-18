using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiCultureRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCultureRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCultureRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>268045d163ea6b1a3e7bfe0674202236</Hash>
</Codenesium>*/