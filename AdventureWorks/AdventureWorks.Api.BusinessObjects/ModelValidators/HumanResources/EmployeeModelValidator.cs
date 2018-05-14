using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiEmployeeModelValidator: AbstractApiEmployeeModelValidator, IApiEmployeeModelValidator
	{
		public ApiEmployeeModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiEmployeeModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeModel model)
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
    <Hash>b469c558ae5807939c79bb112a05d549</Hash>
</Codenesium>*/