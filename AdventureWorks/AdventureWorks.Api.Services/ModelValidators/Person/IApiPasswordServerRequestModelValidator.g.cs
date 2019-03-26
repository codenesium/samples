using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiPasswordServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPasswordServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPasswordServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1f8ebecc2e35389790e805dd92e51330</Hash>
</Codenesium>*/