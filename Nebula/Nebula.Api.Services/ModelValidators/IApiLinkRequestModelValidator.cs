using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiLinkRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1256e017e9f492cc034ea7aa67af1545</Hash>
</Codenesium>*/