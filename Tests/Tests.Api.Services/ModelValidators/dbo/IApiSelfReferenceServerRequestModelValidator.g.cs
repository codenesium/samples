using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiSelfReferenceServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSelfReferenceServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSelfReferenceServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9314adbd8655e98b707c030248aea4c1</Hash>
</Codenesium>*/