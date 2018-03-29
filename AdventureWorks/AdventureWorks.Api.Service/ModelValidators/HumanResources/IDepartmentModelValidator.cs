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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>406581385a5a5771f08da8521c0c0557</Hash>
</Codenesium>*/