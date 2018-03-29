using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractEmployeeDepartmentHistoryModelValidator: AbstractValidator<EmployeeDepartmentHistoryModel>
	{
		public new ValidationResult Validate(EmployeeDepartmentHistoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(EmployeeDepartmentHistoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IEmployeeRepository EmployeeRepository {get; set;}
		public IDepartmentRepository DepartmentRepository {get; set;}
		public IShiftRepository ShiftRepository {get; set;}
		public virtual void DepartmentIDRules()
		{
			RuleFor(x => x.DepartmentID).NotNull();
			RuleFor(x => x.DepartmentID).Must(BeValidDepartment).When(x => x ?.DepartmentID != null).WithMessage("Invalid reference");
		}

		public virtual void ShiftIDRules()
		{
			RuleFor(x => x.ShiftID).NotNull();
			RuleFor(x => x.ShiftID).Must(BeValidShift).When(x => x ?.ShiftID != null).WithMessage("Invalid reference");
		}

		public virtual void StartDateRules()
		{
			RuleFor(x => x.StartDate).NotNull();
		}

		public virtual void EndDateRules()
		{                       }

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		public bool BeValidEmployee(int id)
		{
			Response response = new Response();

			this.EmployeeRepository.GetById(id,response);
			return response.Employees.Count > 0;
		}

		public bool BeValidDepartment(short id)
		{
			Response response = new Response();

			this.DepartmentRepository.GetById(id,response);
			return response.Departments.Count > 0;
		}

		public bool BeValidShift(int id)
		{
			Response response = new Response();

			this.ShiftRepository.GetById(id,response);
			return response.Shifts.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>9a068be6590f0bb526b2d832f4f05afd</Hash>
</Codenesium>*/