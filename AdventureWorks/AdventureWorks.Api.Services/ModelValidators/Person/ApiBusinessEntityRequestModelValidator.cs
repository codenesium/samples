using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiBusinessEntityRequestModelValidator : AbstractApiBusinessEntityRequestModelValidator, IApiBusinessEntityRequestModelValidator
        {
                public ApiBusinessEntityRequestModelValidator(IBusinessEntityRepository businessEntityRepository)
                        : base(businessEntityRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.RowguidRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.RowguidRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>10ddd00c68e8587588f0cbf73dd278cc</Hash>
</Codenesium>*/