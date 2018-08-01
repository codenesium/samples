using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiBusinessEntityContactRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityContactRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityContactRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>74e2374d49a17e8669a6fef3ba3d2bd4</Hash>
</Codenesium>*/