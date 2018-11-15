using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiLinkServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6ae97ed319363893729171c83891b295</Hash>
</Codenesium>*/