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
			this.ShiftIDRules();
			this.StartDateRules();
			this.EndDateRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, EmployeeDepartmentHistoryModel model)
		{
			this.DepartmentIDRules();
			this.ShiftIDRules();
			this.StartDateRules();
			this.EndDateRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>c0d2f9dcec4258c44c7044c89a60e76e</Hash>
</Codenesium>*/