using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiLinkStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkStatusRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkStatusRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d7ff94dc545a1f68b7e1edb7ce660f22</Hash>
</Codenesium>*/