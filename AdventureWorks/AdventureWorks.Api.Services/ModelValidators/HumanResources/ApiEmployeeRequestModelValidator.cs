using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiEmployeeRequestModelValidator : AbstractApiEmployeeRequestModelValidator, IApiEmployeeRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>5a27c07679cd8436c3fba3950bea3128</Hash>
</Codenesium>*/