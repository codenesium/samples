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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>a330a24ca8ee5561cf9c2f3017cc002c</Hash>
</Codenesium>*/