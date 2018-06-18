using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiShiftRequestModelValidator: AbstractApiShiftRequestModelValidator, IApiShiftRequestModelValidator
        {
                public ApiShiftRequestModelValidator(IShiftRepository shiftRepository)
                        : base(shiftRepository)
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
    <Hash>0c2fb5c5b6d625bfc85a322c30fdcd33</Hash>
</Codenesium>*/