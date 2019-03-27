using FluentValidation.Results;
using SecureVideoCRMNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public partial interface IApiVideoServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVideoServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVideoServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b8792df9da6fbe90eedcf8f3a7f5c18c</Hash>
</Codenesium>*/