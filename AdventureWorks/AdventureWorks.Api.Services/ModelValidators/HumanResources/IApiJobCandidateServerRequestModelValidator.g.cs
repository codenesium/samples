using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiJobCandidateServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiJobCandidateServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiJobCandidateServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4c2be4d29ab5cb91d931f78c3beb7041</Hash>
</Codenesium>*/