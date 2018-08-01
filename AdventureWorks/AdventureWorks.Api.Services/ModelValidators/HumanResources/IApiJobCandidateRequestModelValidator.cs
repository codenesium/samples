using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiJobCandidateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiJobCandidateRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiJobCandidateRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f73d36266a09311f35c08b6b918d145f</Hash>
</Codenesium>*/