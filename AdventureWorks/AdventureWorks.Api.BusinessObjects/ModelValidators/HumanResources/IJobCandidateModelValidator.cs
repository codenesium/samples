using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IJobCandidateModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(JobCandidateModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, JobCandidateModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>344ad8536e11441309f52a578c4bf320</Hash>
</Codenesium>*/