using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiShiftRequestModelValidator: AbstractApiShiftRequestModelValidator, IApiShiftRequestModelValidator
        {
                public ApiShiftRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiShiftRequestModel model)
                {
                        this.EndTimeRules();
                        this.ModifiedDateRules();
                        this.NameRules();
                        this.StartTimeRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiShiftRequestModel model)
                {
                        this.EndTimeRules();
                        this.ModifiedDateRules();
                        this.NameRules();
                        this.StartTimeRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>9456fafa744d2a4c2a4ce6e70e5ddc06</Hash>
</Codenesium>*/