using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiClaspServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiClaspServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiClaspServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f84c10f0846d598e6fc051b774899169</Hash>
</Codenesium>*/