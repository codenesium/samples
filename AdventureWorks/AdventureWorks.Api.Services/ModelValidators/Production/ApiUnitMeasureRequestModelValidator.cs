using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiUnitMeasureRequestModelValidator: AbstractApiUnitMeasureRequestModelValidator, IApiUnitMeasureRequestModelValidator
        {
                public ApiUnitMeasureRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiUnitMeasureRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiUnitMeasureRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>78acdd23f8e38f6e4c509be47125f74d</Hash>
</Codenesium>*/