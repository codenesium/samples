using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiBusinessEntityRequestModelValidator: AbstractApiBusinessEntityRequestModelValidator, IApiBusinessEntityRequestModelValidator
        {
                public ApiBusinessEntityRequestModelValidator()
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>95cc2ff867ba6399995b2a7baf06d984</Hash>
</Codenesium>*/