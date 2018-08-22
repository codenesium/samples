using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d1e330749145afc401136d3742e3a509</Hash>
</Codenesium>*/