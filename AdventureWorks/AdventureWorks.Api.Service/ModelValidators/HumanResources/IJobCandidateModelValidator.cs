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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>4b009c071ba6ecff60d7e44048b137fa</Hash>
</Codenesium>*/