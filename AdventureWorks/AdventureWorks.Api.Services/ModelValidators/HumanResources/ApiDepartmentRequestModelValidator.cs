using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiDepartmentRequestModelValidator: AbstractApiDepartmentRequestModelValidator, IApiDepartmentRequestModelValidator
        {
                public ApiDepartmentRequestModelValidator(IDepartmentRepository departmentRepository)
                        : base(departmentRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiDepartmentRequestModel model)
                {
                        this.GroupNameRules();
                        this.ModifiedDateRules();
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(short id, ApiDepartmentRequestModel model)
                {
                        this.GroupNameRules();
                        this.ModifiedDateRules();
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(short id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>6414ee2aa87644552c6fe096e9802df5</Hash>
</Codenesium>*/