using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiCompositePrimaryKeyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCompositePrimaryKeyRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCompositePrimaryKeyRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d89b7e2802298969b49adbd840a10a0c</Hash>
</Codenesium>*/