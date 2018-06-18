using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiEmployeeRequestModelValidator: AbstractApiEmployeeRequestModelValidator, IApiEmployeeRequestModelValidator
        {
                public ApiEmployeeRequestModelValidator(IEmployeeRepository employeeRepository)
                        : base(employeeRepository)
                {
                }

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
                        this.RowguidRules();
                        this.SalariedFlagRules();
                        this.SickLeaveHoursRules();
                        this.VacationHoursRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>d962cec776e244d55ec7f83bcb90e492</Hash>
</Codenesium>*/