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
			this.NationalIDNumberRules();
			this.LoginIDRules();
			this.OrganizationNodeRules();
			this.OrganizationLevelRules();
			this.JobTitleRules();
			this.BirthDateRules();
			this.MaritalStatusRules();
			this.GenderRules();
			this.HireDateRules();
			this.SalariedFlagRules();
			this.VacationHoursRules();
			this.SickLeaveHoursRules();
			this.CurrentFlagRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, EmployeeModel model)
		{
			this.NationalIDNumberRules();
			this.LoginIDRules();
			this.OrganizationNodeRules();
			this.OrganizationLevelRules();
			this.JobTitleRules();
			this.BirthDateRules();
			this.MaritalStatusRules();
			this.GenderRules();
			this.HireDateRules();
			this.SalariedFlagRules();
			this.VacationHoursRules();
			this.SickLeaveHoursRules();
			this.CurrentFlagRules();
			this.RowguidRules();
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
    <Hash>3b95443eeb2970b9bc3e8616bc1cb251</Hash>
</Codenesium>*/