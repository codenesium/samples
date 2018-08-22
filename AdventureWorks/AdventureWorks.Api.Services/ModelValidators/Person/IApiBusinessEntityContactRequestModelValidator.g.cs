using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiBusinessEntityContactRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityContactRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityContactRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ad19cf781390504daa15bf8a02fb79f2</Hash>
</Codenesium>*/