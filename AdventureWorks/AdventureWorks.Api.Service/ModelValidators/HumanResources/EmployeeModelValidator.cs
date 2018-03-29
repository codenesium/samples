using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class EmployeeModelValidator: AbstractEmployeeModelValidator,IEmployeeModelValidator
	{
		public EmployeeModelValidator()
		{   }

		public void CreateMode()
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
		}

		public void UpdateMode()
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
		}

		public void PatchMode()
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
		}
	}
}

/*<Codenesium>
    <Hash>c0a125da7137abf950b69f0b0889b70c</Hash>
</Codenesium>*/