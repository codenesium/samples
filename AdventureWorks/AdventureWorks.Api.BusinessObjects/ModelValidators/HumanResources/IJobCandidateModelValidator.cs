using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiJobCandidateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiJobCandidateRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiJobCandidateRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2d2d044f304638eff262986bd0c6a6a9</Hash>
</Codenesium>*/