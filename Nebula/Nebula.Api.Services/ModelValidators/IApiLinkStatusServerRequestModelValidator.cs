using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiLinkStatusServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkStatusServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkStatusServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>56da268364aaf2f231532c6e253c233c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/