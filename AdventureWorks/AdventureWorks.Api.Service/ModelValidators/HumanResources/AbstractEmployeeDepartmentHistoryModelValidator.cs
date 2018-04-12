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

		public IEmployeeRepository EmployeeRepository { get; set; }
		public IDepartmentRepository DepartmentRepository { get; set; }
		public IShiftRepository ShiftRepository { get; set; }
		public virtual void DepartmentIDRules()
		{
			this.RuleFor(x => x.DepartmentID).NotNull();
			this.RuleFor(x => x.DepartmentID).Must(this.BeValidDepartment).When(x => x ?.DepartmentID != null).WithMessage("Invalid reference");
		}

		public virtual void ShiftIDRules()
		{
			this.RuleFor(x => x.ShiftID).NotNull();
			this.RuleFor(x => x.ShiftID).Must(this.BeValidShift).When(x => x ?.ShiftID != null).WithMessage("Invalid reference");
		}

		public virtual void StartDateRules()
		{
			this.RuleFor(x => x.StartDate).NotNull();
		}

		public virtual void EndDateRules()
		{                       }

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidEmployee(int id)
		{
			return this.EmployeeRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidDepartment(short id)
		{
			return this.DepartmentRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidShift(int id)
		{
			return this.ShiftRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>064fa91341842ede447d29400c38682e</Hash>
</Codenesium>*/