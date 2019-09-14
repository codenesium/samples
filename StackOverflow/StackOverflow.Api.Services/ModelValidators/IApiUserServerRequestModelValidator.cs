using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiUserServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUserServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiUserServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bdf0ad2a915933a53a7d029328848417</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/