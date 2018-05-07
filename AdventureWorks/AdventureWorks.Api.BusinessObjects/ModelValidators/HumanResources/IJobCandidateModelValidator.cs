using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IJobCandidateModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(JobCandidateModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, JobCandidateModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>13ba9156cc64d2025f662f3d7fa769dc</Hash>
</Codenesium>*/