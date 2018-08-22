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
    <Hash>9fc82694a8c75b2b418dac2932973620</Hash>
</Codenesium>*/