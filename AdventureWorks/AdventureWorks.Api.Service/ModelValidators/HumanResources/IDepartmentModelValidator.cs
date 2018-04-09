using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IDepartmentModelValidator
	{
		ValidationResult Validate(DepartmentModel entity);

		Task<ValidationResult> ValidateAsync(DepartmentModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>fbd8f244dbfacb3e02e2e7076d1c0b7e</Hash>
</Codenesium>*/