using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
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
    <Hash>4e8b1ff142529f1b41b1ea006bd9191c</Hash>
</Codenesium>*/