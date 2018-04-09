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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>12b18b084570ce4f88c388eb77a54aed</Hash>
</Codenesium>*/