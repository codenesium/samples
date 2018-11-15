using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiEmployeeServerRequestModelValidator : AbstractApiEmployeeServerRequestModelValidator, IApiEmployeeServerRequestModelValidator
	{
		public ApiEmployeeServerRequestModelValidator(IEmployeeRepository employeeRepository)
			: base(employeeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEmployeeServerRequestModel model)
		{
			this.BirthDateRules();
			this.CurrentFlagRules();
			this.GenderRules();
			this.HireDateRules();
			this.JobTitleRules();
			this.LoginIDRules();
			this.MaritalStatuRules();
			this.ModifiedDateRules();
			this.NationalIDNumberRules();
			this.OrganizationLevelRules();
			this.RowguidRules();
			this.SalariedFlagRules();
			this.SickLeaveHourRules();
			this.VacationHourRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeServerRequestModel model)
		{
			this.BirthDateRules();
			this.CurrentFlagRules();
			this.GenderRules();
			this.HireDateRules();
			this.JobTitleRules();
			this.LoginIDRules();
			this.MaritalStatuRules();
			this.ModifiedDateRules();
			this.NationalIDNumberRules();
			this.OrganizationLevelRules();
			this.RowguidRules();
			this.SalariedFlagRules();
			this.SickLeaveHourRules();
			this.VacationHourRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>4f3c9452b54c005017e9e2c8aa89714c</Hash>
</Codenesium>*/