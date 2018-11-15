using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiVersionInfoServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVersionInfoServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(long id, ApiVersionInfoServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(long id);
	}
}

/*<Codenesium>
    <Hash>a121d9c1a49b28519c476fff27101ffc</Hash>
</Codenesium>*/