using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IJobCandidateModelValidator
	{
		ValidationResult Validate(JobCandidateModel entity);

		Task<ValidationResult> ValidateAsync(JobCandidateModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>0ef0cfc823c7b86572e1ca8bc4eb8657</Hash>
</Codenesium>*/