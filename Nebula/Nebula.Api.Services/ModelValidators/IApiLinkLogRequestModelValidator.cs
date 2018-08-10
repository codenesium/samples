using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiLinkLogRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkLogRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkLogRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b62e885df1c28fa77bf001e8fb886916</Hash>
</Codenesium>*/