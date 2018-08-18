using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiJobCandidateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiJobCandidateRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiJobCandidateRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5b9629128416df194192904cd5292f6e</Hash>
</Codenesium>*/