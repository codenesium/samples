using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiSysdiagramRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSysdiagramRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSysdiagramRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>913250f797935e2652a31b3e839d82bb</Hash>
</Codenesium>*/