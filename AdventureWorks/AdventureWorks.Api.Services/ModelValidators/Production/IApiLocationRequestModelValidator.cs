using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiLocationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLocationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(short id, ApiLocationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>60d9c716c2c12eba097b83a785df2f36</Hash>
</Codenesium>*/