using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiLinkTypeServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkTypeServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkTypeServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>afe51b48c28cc5076f91321e1531fab5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/