using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiStoreServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStoreServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStoreServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5da5fdcf5b79b91c5e93ae21f601e951</Hash>
</Codenesium>*/