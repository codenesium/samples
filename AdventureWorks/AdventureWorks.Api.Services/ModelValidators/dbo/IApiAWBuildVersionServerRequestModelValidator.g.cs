using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiAWBuildVersionServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAWBuildVersionServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAWBuildVersionServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c130e7cbbb78b5d4025f68846024c812</Hash>
</Codenesium>*/