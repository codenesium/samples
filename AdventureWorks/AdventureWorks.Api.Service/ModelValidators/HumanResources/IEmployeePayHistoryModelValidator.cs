using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IEmployeePayHistoryModelValidator
	{
		ValidationResult Validate(EmployeePayHistoryModel entity);

		Task<ValidationResult> ValidateAsync(EmployeePayHistoryModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>000fcf135574b95edec5773566289cf3</Hash>
</Codenesium>*/