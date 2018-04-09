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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>a1553508b5d87e7970269b563fc293bc</Hash>
</Codenesium>*/