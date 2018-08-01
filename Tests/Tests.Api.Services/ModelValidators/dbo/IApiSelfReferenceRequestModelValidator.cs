using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public interface IApiSelfReferenceRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSelfReferenceRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSelfReferenceRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dbb43950431f6ac3de0ca29c3cbc0531</Hash>
</Codenesium>*/