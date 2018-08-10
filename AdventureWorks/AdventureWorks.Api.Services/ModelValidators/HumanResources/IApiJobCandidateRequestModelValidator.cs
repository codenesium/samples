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
    <Hash>8e7f270b96ba7b1a6c309e1dd2b91b60</Hash>
</Codenesium>*/