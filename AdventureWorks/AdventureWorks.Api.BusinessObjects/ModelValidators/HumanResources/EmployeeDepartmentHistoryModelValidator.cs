using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class EmployeeDepartmentHistoryModelValidator: AbstractEmployeeDepartmentHistoryModelValidator, IEmployeeDepartmentHistoryModelValidator
	{
		public EmployeeDepartmentHistoryModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(EmployeeDepartmentHistoryModel model)
		{
			this.DepartmentIDRules();
			this.EndDateRules();
			this.ModifiedDateRules();
			this.ShiftIDRules();
			this.StartDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, EmployeeDepartmentHistoryModel model)
		{
			this.DepartmentIDRules();
			this.EndDateRules();
			this.ModifiedDateRules();
			this.ShiftIDRules();
			this.StartDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>2fffeebc8a627772b3c3994effb8eaef</Hash>
</Codenesium>*/