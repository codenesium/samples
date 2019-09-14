using FluentValidation.Results;
using SecureVideoCRMNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public partial interface IApiUserServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUserServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiUserServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0b40ea8926e2781d18ddb06e0abafc91</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/