using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class EmployeeModelValidator: AbstractEmployeeModelValidator, IEmployeeModelValidator
	{
		public EmployeeModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(EmployeeModel model)
		{
			this.BirthDateRules();
			this.CurrentFlagRules();
			this.GenderRules();
			this.HireDateRules();
			this.JobTitleRules();
			this.LoginIDRules();
			this.MaritalStatusRules();
			this.ModifiedDateRules();
			this.NationalIDNumberRules();
			this.OrganizationLevelRules();
			this.OrganizationNodeRules();
			this.RowguidRules();
			this.SalariedFlagRules();
			this.SickLeaveHoursRules();
			this.VacationHoursRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, EmployeeModel model)
		{
			this.BirthDateRules();
			this.CurrentFlagRules();
			this.GenderRules();
			this.HireDateRules();
			this.JobTitleRules();
			this.LoginIDRules();
			this.MaritalStatusRules();
			this.ModifiedDateRules();
			this.NationalIDNumberRules();
			this.OrganizationLevelRules();
			this.OrganizationNodeRules();
			this.RowguidRules();
			this.SalariedFlagRules();
			this.SickLeaveHoursRules();
			this.VacationHoursRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>c8fbebccc3f94bfd3bb3086b9cc1cd78</Hash>
</Codenesium>*/