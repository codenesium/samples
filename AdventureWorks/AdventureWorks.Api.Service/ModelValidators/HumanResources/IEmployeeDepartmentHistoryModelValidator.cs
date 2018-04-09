using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IEmployeeDepartmentHistoryModelValidator
	{
		ValidationResult Validate(EmployeeDepartmentHistoryModel entity);

		Task<ValidationResult> ValidateAsync(EmployeeDepartmentHistoryModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>cd200c2cd184bb3790c44bb2aab3bb4e</Hash>
</Codenesium>*/