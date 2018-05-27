using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiEmployeeRequestModelValidator: AbstractApiEmployeeRequestModelValidator, IApiEmployeeRequestModelValidator
	{
		public ApiEmployeeRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiEmployeeRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeRequestModel model)
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
    <Hash>c66ca249f60860012ad63b57955b8035</Hash>
</Codenesium>*/