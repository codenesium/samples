using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiLinkStatuRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkStatuRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkStatuRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>538cf34acd8dfe631caa3170b8b09b23</Hash>
</Codenesium>*/