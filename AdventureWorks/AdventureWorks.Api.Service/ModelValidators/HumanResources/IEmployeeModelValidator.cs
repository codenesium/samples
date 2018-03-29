using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IEmployeeModelValidator
	{
		ValidationResult Validate(EmployeeModel entity);

		Task<ValidationResult> ValidateAsync(EmployeeModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>bb6bca42077139aeab9a728f0c7ecaf9</Hash>
</Codenesium>*/