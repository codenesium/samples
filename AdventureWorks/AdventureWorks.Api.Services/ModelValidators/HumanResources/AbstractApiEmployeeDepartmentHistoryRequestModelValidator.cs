using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiEmployeeDepartmentHistoryRequestModelValidator: AbstractValidator<ApiEmployeeDepartmentHistoryRequestModel>
        {
                private int existingRecordId;

                IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository;

                public AbstractApiEmployeeDepartmentHistoryRequestModelValidator(IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository)
                {
                        this.employeeDepartmentHistoryRepository = employeeDepartmentHistoryRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiEmployeeDepartmentHistoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void DepartmentIDRules()
                {
                }

                public virtual void EndDateRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void ShiftIDRules()
                {
                }

                public virtual void StartDateRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>f34f4c02a47fd3a59d88a9b7eff9568c</Hash>
</Codenesium>*/