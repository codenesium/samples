using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiJobCandidateModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiJobCandidateModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiJobCandidateModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>26489383356d9ad113f2c9b1fdba1b0a</Hash>
</Codenesium>*/