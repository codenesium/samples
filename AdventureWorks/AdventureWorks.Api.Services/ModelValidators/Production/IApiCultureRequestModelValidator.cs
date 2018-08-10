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
    <Hash>00e2551bef9794a38bb05ae3bef285db</Hash>
</Codenesium>*/