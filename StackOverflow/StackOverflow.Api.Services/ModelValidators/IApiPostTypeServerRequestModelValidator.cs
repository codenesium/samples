using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostTypeServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostTypeServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostTypeServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ebc5d6d0d2571804b72bab4888a80c54</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/