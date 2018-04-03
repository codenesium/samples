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

		public virtual void DepartmentIDRules()
		{
			RuleFor(x => x.DepartmentID).NotNull();
		}

		public virtual void ShiftIDRules()
		{
			RuleFor(x => x.ShiftID).NotNull();
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
	}
}

/*<Codenesium>
    <Hash>5a449df4af617dbd2959b1812c2604f7</Hash>
</Codenesium>*/