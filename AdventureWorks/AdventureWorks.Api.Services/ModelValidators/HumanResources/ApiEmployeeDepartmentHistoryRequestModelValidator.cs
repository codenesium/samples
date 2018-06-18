using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiEmployeeDepartmentHistoryRequestModelValidator: AbstractApiEmployeeDepartmentHistoryRequestModelValidator, IApiEmployeeDepartmentHistoryRequestModelValidator
        {
                public ApiEmployeeDepartmentHistoryRequestModelValidator(IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository)
                        : base(employeeDepartmentHistoryRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiEmployeeDepartmentHistoryRequestModel model)
                {
                        this.DepartmentIDRules();
                        this.EndDateRules();
                        this.ModifiedDateRules();
                        this.ShiftIDRules();
                        this.StartDateRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeDepartmentHistoryRequestModel model)
                {
                        this.DepartmentIDRules();
                        this.EndDateRules();
                        this.ModifiedDateRules();
                        this.ShiftIDRules();
                        this.StartDateRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>86fabf02b86e1c0e394bb1b52a092750</Hash>
</Codenesium>*/