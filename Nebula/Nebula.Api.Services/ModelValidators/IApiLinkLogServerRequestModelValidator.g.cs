using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiLinkLogServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkLogServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkLogServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>198848acebf84f03eea6b61c9a1089fa</Hash>
</Codenesium>*/