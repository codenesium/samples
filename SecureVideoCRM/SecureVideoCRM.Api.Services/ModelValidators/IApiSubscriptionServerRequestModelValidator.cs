using FluentValidation.Results;
using SecureVideoCRMNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public partial interface IApiSubscriptionServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSubscriptionServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSubscriptionServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d6987ede9f65680cdbcfc51eb2f09b40</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/