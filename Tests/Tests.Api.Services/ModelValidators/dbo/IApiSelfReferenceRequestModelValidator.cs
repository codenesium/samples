using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiSelfReferenceRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSelfReferenceRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSelfReferenceRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f010bc460b970cdfb2f12616a5e0eca9</Hash>
</Codenesium>*/